using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiDoc.Models;
using ApiDoc.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDoc.Services;

namespace ApiDoc.Controllers
{
  [Route("auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {



    private readonly DatabaseContext db;

    public AuthController(DatabaseContext context)
    {
      this.db = context;
    }

    [HttpPost("signup")]
    public async Task<ActionResult> SignUpUser(NewUserModel userData)
    {
      if (userData.Email.Contains("@gmail.com"))
      {
        return BadRequest(new { Message = "Sorry, no google accounts" });
      }


      var existingUserEmail = await this.db.Users.FirstOrDefaultAsync(f => f.Email == userData.Email);
      if (existingUserEmail != null)
      {
        return BadRequest(new { Message = "email address is already exists" });
      }

      var user = new User
      {
        Email = userData.Email,
        FirstName = userData.FirstName,
        LastName = userData.LastName,
        HashedPassword = ""
      };
      // hash the password

      var hashed = new PasswordHasher<User>().HashPassword(user, userData.Password);
      user.HashedPassword = hashed;

      this.db.Users.Add(user);
      await this.db.SaveChangesAsync();
      var rv = new AuthService().CreateToken(user);
      return Ok(rv);
    }


    [HttpPost("login")]
    public async Task<ActionResult> LoginUser(LoginViewModel loginData)
    {
      var user = await this.db.Users.FirstOrDefaultAsync(f => f.FirstName == loginData.FirstName);
      if (user == null)
      {
        return BadRequest(new { Message = "User does not exist" });
      }

      var verificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, loginData.Password);

      if (verificationResult == PasswordVerificationResult.Success)
      {
        var rv = new AuthService().CreateToken(user);
        return Ok(rv);
      }
      else
      {
        return BadRequest(new { message = "Wrong password" });
      }
    }

  }
}
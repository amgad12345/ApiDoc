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
  [Route("Docauth")]
  [ApiController]
  public class DocAuthController : ControllerBase
  {



    private readonly DatabaseContext db;

    public DocAuthController(DatabaseContext context)
    {
      this.db = context;
    }

    [HttpPost("Docsignup")]
    public async Task<ActionResult> SignUpUser(DocNewUserModel userData)
    {
      


      var existingUserId = await this.db.DoctorAdmins.FirstOrDefaultAsync(f => f.Username == userData.Username);
      if (existingUserId != null)
      {
        return BadRequest(new { Message = "Id  already exists" });
      }

      var duser = new DoctorAdmin
      {
        Username = userData.Username,
        DoctorId= userData.DoctorId, //
        HashedPassword = ""
      };
      // hash the password

      var hashed = new PasswordHasher<DoctorAdmin>().HashPassword(duser, userData.Password);
      duser.HashedPassword = hashed;

      this.db.DoctorAdmins.Add(duser);
      await this.db.SaveChangesAsync();
      var rv = new DocAuthService().CreateToken(duser);
      return Ok(rv);
    }


    [HttpPost("Doclogin")]
    public async Task<ActionResult> LoginUser(DocLoginViewModel loginData)
    {
      var duser = await this.db.DoctorAdmins.FirstOrDefaultAsync(f => f.Username == loginData.Username);
      if (duser == null)
      {
        return BadRequest(new { Message = "User does not exist" });
      }

      var verificationResult = new PasswordHasher<DoctorAdmin>().VerifyHashedPassword(duser, duser.HashedPassword, loginData.Password);

      if (verificationResult == PasswordVerificationResult.Success)
      {
        var rv = new DocAuthService().CreateToken(duser);
        return Ok(rv);
      }
      else
      {
        return BadRequest(new { message = "Wrong password" });
      }
    }

  }
}
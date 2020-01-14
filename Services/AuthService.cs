using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiDoc.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace ApiDoc.Services
{
  public class AuthService
  {
    public AuthenticatedData CreateToken(Models.User user)
    {
      var expirationTime = DateTime.UtcNow.AddHours(10);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim("id", user.Id.ToString()),
      }),
        Expires = expirationTime,
        SigningCredentials = new SigningCredentials(
               new SymmetricSecurityKey(Encoding.ASCII.GetBytes("bRhYJRlZvBj2vW4MrV5HVdPgIE6VMtCFB0kTtJ1m")),
              SecurityAlgorithms.HmacSha256Signature
          )
      };
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
      return new AuthenticatedData
      {
        FirstName = user.FirstName,
        LastName = user.LastName,
        Token = token,
        UserId = user.Id,
        ExpirationTime = expirationTime
      };
    }
  }
}
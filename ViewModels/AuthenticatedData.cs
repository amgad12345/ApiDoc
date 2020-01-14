  
using System;

namespace ApiDoc.ViewModels
{
  public class AuthenticatedData
  {
    public int UserId { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string Token { get; set; }
    public DateTime ExpirationTime { get; set; }
  }
}
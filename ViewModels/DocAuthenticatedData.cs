  
using System;

namespace ApiDoc.ViewModels
{
  public class DocAuthenticatedData
  {
    public int UserId { get; set; }

    public string Username { get; set; }
  
     public int DoctorId { get; set; }
      public string Token { get; set; }
    public DateTime ExpirationTime { get; set; }
  }
}
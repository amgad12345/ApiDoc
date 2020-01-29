using System.ComponentModel.DataAnnotations;

namespace ApiDoc.Models
{
  public class DoctorAdmin
  {
    public int Id { get; set; }
    [Required]
    
    public string Username { get; set; }
    public string HashedPassword { get; set; }

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public string ProfileUrl { get; set; }
  }
}
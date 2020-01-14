using System.ComponentModel.DataAnnotations;

namespace ApiDoc.Models
{
  public class User
  {
    public int Id { get; set; }
    [Required]
    
    public string HashedPassword { get; set; }

    public string Email { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string ProfileUrl { get; set; }
  }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ApiDoc.Models
{

  public class Doctor
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Type { get; set; }

    public long PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Adress { get; set; }

    public decimal Review { get; set; }


    public List<AppointmentForm> AppointmentForms { get; set; }
      = new List<AppointmentForm>();

  }

}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiDoc.ViewModels
{

  public class DoctorDetails
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Type { get; set; }

    public long PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Adress { get; set; }

    public decimal Review { get; set; }


    public List<CreatedAppointmentForm> AppointmentForms { get; set; }
      = new List<CreatedAppointmentForm>();

  }

}
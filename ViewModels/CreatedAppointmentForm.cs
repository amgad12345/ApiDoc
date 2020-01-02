using System;

namespace ApiDoc.ViewModels
{

  public class CreatedAppointmentForm
  {
    public int Id { get; set; }


    public DateTime AppointmentDate { get; set; }

    public string Discription { get; set; }

    public string LastNanme { get; set; }

    public string Email { get; set; }

    public int DoctorId { get; set; }


  }

}
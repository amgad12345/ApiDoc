using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ApiDoc.Models
{

  public class AppointmentForm
  {
    public int Id { get; set; }

    
    public DateTime AppointmentDate { get; set; } 

    public string Discription { get; set; }

     public string FirstNanme { get; set; }
    
    public string LastNanme { get; set; }
    
    public long PhoneNumber { get; set; }
    public string Email { get; set; }

    public int DoctorId { get; set; }


    public Doctor Doctor { get; set; }


  }
  

}
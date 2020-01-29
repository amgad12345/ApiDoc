using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ApiDoc.Models;
using ApiDoc.ViewModels;

namespace ApiDoc.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AppointmentFormController : ControllerBase
  {
    [HttpPost]
    public ActionResult CreateAppointmentForm(AppointmentForm vm)
    {
      var db = new DatabaseContext();

      var doctor = db.Doctors
        .FirstOrDefault(dr => dr.Id == vm.DoctorId);
      if (doctor == null)
      {
        return NotFound();
      }
      else
      {
        var report = new AppointmentForm
        {
          AppointmentDate = vm.AppointmentDate,
          Discription = vm.Discription,
          PhoneNumber = vm.PhoneNumber,
          FirstNanme = vm.FirstNanme,
          LastNanme = vm.LastNanme,
          Email = vm.Email,
          DoctorId = vm.DoctorId
        };
        db.AppointmentForms.Add(report);
        db.SaveChanges();
        var rv = new AppointmentForm
        {
          Id = report.Id,
          AppointmentDate = report.AppointmentDate,
          Discription = report.Discription,
          FirstNanme = report.FirstNanme,
          LastNanme = report.LastNanme,
          PhoneNumber = report.PhoneNumber,
          Email = report.Email,
          DoctorId = report.DoctorId,
        };
        return Ok(rv);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAppointment(int id)
    {
      var db = new DatabaseContext();
      var app = db.AppointmentForms.FirstOrDefault(st => st.Id == id);
      Email.SendEmail(app.Email);  // is doctor in the right place
      if (app == null)
      {
        return NotFound();
      }
      else
      {
        db.AppointmentForms.Remove(app);
        db.SaveChanges();

        return Ok();
      }
    }

  }
}
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
    public ActionResult CreateAppointmentForm(CreatedAppointmentForm vm)
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
          LastNanme = vm.LastNanme,
          Email = vm.Email,
          DoctorId = vm.DoctorId
        };
        db.AppointmentForms.Add(report);
        db.SaveChanges();
        var rv = new CreatedAppointmentForm
        {
          Id = report.Id,
          AppointmentDate = report.AppointmentDate,
          Discription = report.Discription,
          LastNanme = report.LastNanme,
          Email = report.Email,
          DoctorId = report.DoctorId,
        };
        return Ok(rv);
      }
    }
  }
}
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDoc.Models;
using ApiDoc.ViewModels;

namespace ApiDoc.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class DoctorController : ControllerBase
  {

    [HttpGet("getalldockers")]
    public ActionResult GetAllDoctors()
    {
      // return a list of all students ordered by fullname
      var db = new DatabaseContext();
      return Ok(db.Doctors.OrderBy(doctor => doctor.Type));
    }


    [HttpGet("getdoc/{id}")]
    public ActionResult GetOneDoctor2(int id)
    {
      var db = new DatabaseContext();
      var doctor = db.Doctors.Include(i => i.AppointmentForms).FirstOrDefault(dr => dr.Id == id);
      if (doctor == null)
      {
        return NotFound();
      }
      else
      {
        // create our json object///////////////////
        var rv = new DoctorDetails
        {
          Id = doctor.Id,
          Name = doctor.Name,
          Email = doctor.Email,
          Type = doctor.Type,
          Review = doctor.Review,
          Adress = doctor.Adress,
          PhoneNumber = doctor.PhoneNumber,
          AppointmentForms = doctor.AppointmentForms.Select(af => new CreatedAppointmentForm
          {
            AppointmentDate = af.AppointmentDate,
            LastNanme = af.LastNanme,
            Discription = af.Discription,
            Email = af.Email,
            DoctorId = af.DoctorId,
            Id = af.Id
          }).ToList()
        };
        return Ok(rv);
      }
    }




    [HttpGet("getdent/{type}")]
    public ActionResult GetDentists(string type)
    {
      var db = new DatabaseContext();
      var doctors = db.Doctors.Where(it => it.Type == type);
      if (doctors == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(doctors);
      }
    }

    [HttpGet("{id}")]
    public ActionResult GetOneDoctor(int id)
    {
      var db = new DatabaseContext();
      var doctor = db.Doctors.FirstOrDefault(it => it.Id == id);
      if (doctor == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(doctor);
      }
    }

    [HttpPost]
    public ActionResult CreateDoctor(Doctor doctor)
    {
      var db = new DatabaseContext();
      doctor.Id = 0;
      db.Doctors.Add(doctor);
      db.SaveChanges();
      return Ok(doctor);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateDoctor(Doctor doctor)
    {
      var db = new DatabaseContext();
      var prevDoctor = db.Doctors.FirstOrDefault(st => st.Id == doctor.Id);
      if (prevDoctor == null)
      {
        return NotFound();
      }
      else
      {
        prevDoctor.Name = doctor.Name;
        prevDoctor.Type = doctor.Type;
        prevDoctor.Email = doctor.Email;
        prevDoctor.PhoneNumber = doctor.PhoneNumber;
        prevDoctor.Adress = doctor.Adress;
        prevDoctor.Review = doctor.Review;
        db.SaveChanges();
        return Ok(prevDoctor);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteStudent(int id)
    {
      var db = new DatabaseContext();
      var doctor = db.Doctors.FirstOrDefault(st => st.Id == id);
      if (doctor == null)
      {
        return NotFound();
      }
      else
      {
        db.Doctors.Remove(doctor);
        db.SaveChanges();
        return Ok();
      }
    }

  }
}
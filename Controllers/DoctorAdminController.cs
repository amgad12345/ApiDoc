using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiDoc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiDoc.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class DoctorAdminController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public DoctorAdminController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: api/User
    [HttpGet]

    public async Task<ActionResult<IEnumerable<DoctorAdmin>>> GetUsers()
    {
      return await _context.DoctorAdmins.ToListAsync();
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorAdmin>> GetUser(int id)
    {
      var duser = await _context.DoctorAdmins.FindAsync(id);

      if (duser == null)
      {
        return NotFound();
      }

      return duser;
    }

    // PUT: api/User/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, DoctorAdmin duser)
    {
      if (id != duser.Id)
      {
        return BadRequest();
      }

      _context.Entry(duser).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/User
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see https://aka.ms/RazorPagesCRUD.
    [HttpPost]
    public async Task<ActionResult<DoctorAdmin>> PostUser(DoctorAdmin duser)
    {
      _context.DoctorAdmins.Add(duser);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUser", new { id = duser.Id }, duser);
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<DoctorAdmin>> DeleteUser(int id)
    {
      var duser = await _context.DoctorAdmins.FindAsync(id);
      if (duser == null)
      {
        return NotFound();
      }

      _context.DoctorAdmins.Remove(duser);
      await _context.SaveChangesAsync();

      return duser;
    }

    private bool UserExists(int id)
    {
      return _context.DoctorAdmins.Any(e => e.Id == id);
    }
  }
}
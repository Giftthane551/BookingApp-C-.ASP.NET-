using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Models;
using Booking.Data;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorRegistrationsController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public DoctorRegistrationsController(VehicleDbContext context)
        {
            _context = context;
        }

        // POST: api/DoctorRegistrations
        [HttpPost]
        public async Task<IActionResult> PostDoctorRegistration([FromBody] DoctorRegistration doctorRegistration)
        {
            if (doctorRegistration == null)
            {
                return BadRequest("Doctor registration data is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Returns detailed error messages about invalid fields
            }

            // Add the new doctor registration to the database
            _context.DoctorRegistrations.Add(doctorRegistration);
            await _context.SaveChangesAsync();

            // Return a response indicating the doctor has been successfully created
            return CreatedAtAction(nameof(PostDoctorRegistration), new { id = doctorRegistration.Id }, doctorRegistration);
        }
    }
}

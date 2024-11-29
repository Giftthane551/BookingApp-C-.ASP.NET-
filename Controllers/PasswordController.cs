using Microsoft.AspNetCore.Mvc;
using Booking.Models;
using Booking.Services;
using Booking.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly VehicleDbContext _context;
        private readonly PasswordManager _passwordManager;

        public PasswordController(VehicleDbContext context, PasswordManager passwordManager)
        {
            _context = context;
            _passwordManager = passwordManager;
        }

        // POST: api/Password/SetPassword
        [HttpPost("SetPassword")]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Password is required.");
            }

            var doctor = await _context.DoctorRegistrations.FindAsync(request.DoctorId);
            if (doctor == null)
            {
                return NotFound("Doctor not found.");
            }

            // Hash the password
            var hashedPassword = _passwordManager.HashPassword(doctor, request.Password);

            // Save the hashed password to the DoctorRegistration model
            doctor.PasswordHash = hashedPassword;

            // Update the doctor record
            _context.DoctorRegistrations.Update(doctor);
            await _context.SaveChangesAsync();

            return Ok("Password set successfully.");
        }
    }
}

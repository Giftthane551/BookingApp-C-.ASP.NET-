using Booking.Data;
using Booking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public AppointmentsController(VehicleDbContext context)
        {
            _context = context;
        }

        // POST /api/appointments
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null || string.IsNullOrWhiteSpace(appointment.FirstName) || string.IsNullOrWhiteSpace(appointment.LastName))
                return BadRequest("Invalid appointment data.");

            appointment.CreatedDate = DateTime.UtcNow;

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Appointment created successfully.", appointment });
        }

        // GET /api/appointments
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return Ok(appointments);
        }
    }
}

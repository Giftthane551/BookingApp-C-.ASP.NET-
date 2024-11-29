using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking.Data;
using Booking.Models;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingFormDataController : ControllerBase
    {
        private readonly VehicleDbContext _context;

        public BookingFormDataController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: api/BookingFormData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingFormData>>> GetAllBookingFormData()
        {
            return await _context.BookingFormData.ToListAsync();
        }

        // POST: api/BookingFormData
        [HttpPost]
        public async Task<ActionResult<BookingFormData>> CreateBookingFormData([FromBody] BookingFormData bookingFormData)
        {
            if (bookingFormData == null)
            {
                return BadRequest("Booking data is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BookingFormData.Add(bookingFormData);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllBookingFormData), new { id = bookingFormData.Id }, bookingFormData);
        }
    }
}

using Booking.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly VehicleDbContext _context;

        public AppointmentRepository(VehicleDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new appointment to the database.
        /// </summary>
        /// <param name="appointment">The appointment to add.</param>
        public async Task AddAppointmentAsync(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null.");
            }

            appointment.CreatedDate = DateTime.UtcNow;
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all appointments from the database.
        /// </summary>
        /// <returns>List of appointments.</returns>
        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            return await _context.Appointments
                                 .OrderBy(a => a.CreatedDate) // Optional: Order by creation date
                                 .ToListAsync();
        }
    }
}

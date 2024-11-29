using Booking.Data; // Replace with your actual namespace for DbContext
using Booking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly VehicleDbContext _context;

        public DoctorRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task AddDoctorAsync(DoctorRegistration doctor)
        {
            _context.DoctorRegistrations.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DoctorRegistration>> GetDoctorsAsync()
        {
            return await _context.DoctorRegistrations.ToListAsync();
        }

        public async Task<DoctorRegistration?> GetDoctorByIdAsync(int id)
        {
            return await _context.DoctorRegistrations.FindAsync(id);
        }

        public async Task UpdateDoctorAsync(DoctorRegistration doctor)
        {
            _context.DoctorRegistrations.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.DoctorRegistrations.FindAsync(id);
            if (doctor != null)
            {
                _context.DoctorRegistrations.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}

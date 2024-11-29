using Booking.Models;
using Booking.Services;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }

        public DbSet<VehicleLocation> VehicleLocations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorRegistration> DoctorRegistrations { get; set; }
        public DbSet<BookingFormData> BookingFormData { get; set; }
    }
}

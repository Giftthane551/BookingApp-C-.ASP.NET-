using Booking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Services
{
    public interface IDoctorRepository
    {
        Task AddDoctorAsync(DoctorRegistration doctor);
        Task<List<DoctorRegistration>> GetDoctorsAsync();
        Task<DoctorRegistration?> GetDoctorByIdAsync(int id);
        Task UpdateDoctorAsync(DoctorRegistration doctor);
        Task DeleteDoctorAsync(int id);
    }
}

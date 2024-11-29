using Booking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Models;

namespace Booking.Services
{
    public interface IBookingFormDataRepository
    {
        Task<IEnumerable<BookingFormData>> GetAllAsync();
        Task<BookingFormData> GetByIdAsync(int id);
        Task AddAsync(BookingFormData bookingFormData);
        Task UpdateAsync(BookingFormData bookingFormData);
        Task DeleteAsync(int id);
    }
}

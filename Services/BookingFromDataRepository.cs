using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Data;
using Booking.Models;
using Microsoft.EntityFrameworkCore;
using Booking.Data;
using Booking.Models;

namespace Booking.Services
{
    public class BookingFormDataRepository : IBookingFormDataRepository
    {
        private readonly VehicleDbContext _context;

        public BookingFormDataRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingFormData>> GetAllAsync()
        {
            return await _context.BookingFormData.ToListAsync();
        }

        public async Task<BookingFormData> GetByIdAsync(int id)
        {
            return await _context.BookingFormData.FindAsync(id);
        }

        public async Task AddAsync(BookingFormData bookingFormData)
        {
            await _context.BookingFormData.AddAsync(bookingFormData);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookingFormData bookingFormData)
        {
            _context.BookingFormData.Update(bookingFormData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bookingFormData = await _context.BookingFormData.FindAsync(id);
            if (bookingFormData != null)
            {
                _context.BookingFormData.Remove(bookingFormData);
                await _context.SaveChangesAsync();
            }
        }
    }
}

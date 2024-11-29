using Booking.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Booking.Services
{
    public class PasswordManager
    {
        private readonly IPasswordHasher<DoctorRegistration> _passwordHasher;

        public PasswordManager(IPasswordHasher<DoctorRegistration> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        // Hash the password
        public string HashPassword(DoctorRegistration doctorRegistration, string password)
        {
            return _passwordHasher.HashPassword(doctorRegistration, password);
        }

        // Verify the password
        public bool VerifyPassword(DoctorRegistration doctorRegistration, string password, string hashedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(doctorRegistration, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}

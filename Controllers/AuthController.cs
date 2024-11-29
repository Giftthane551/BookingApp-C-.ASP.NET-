using Booking.Data;
using Booking.Models;
using Booking.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IPasswordHasher<DoctorRegistration> _passwordHasher;
        private readonly VehicleDbContext _context;

        public AuthController(IPasswordHasher<DoctorRegistration> passwordHasher, VehicleDbContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Email and Password are required.");
            }

            // Fetch the doctor record from the database by email
            var doctor = await _context.DoctorRegistrations
                                        .FirstOrDefaultAsync(d => d.Email == loginRequest.Email);

            if (doctor == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Verify password
            var result = _passwordHasher.VerifyHashedPassword(doctor, doctor.PasswordHash, loginRequest.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Password matched, create a JWT token (this is a simple implementation)
            var token = GenerateJwtToken(doctor);

            return Ok(new { Token = token });
        }

        // Function to generate JWT token (You can customize it as per your needs)
        private string GenerateJwtToken(DoctorRegistration doctor)
        {
            // This is a simple version. In real-life scenarios, you would add more claims like role, etc.
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyz123456");  // Make sure to keep your secret key safe.
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, doctor.Email),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, doctor.Id.ToString())
                }),
                Expires = System.DateTime.UtcNow.AddHours(1),  // Token expiration time
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

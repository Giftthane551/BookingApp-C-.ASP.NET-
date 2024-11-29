using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class DoctorRegistration
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string IdNumber { get; set; }

        [Required]
        public string ContactDetails { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int DoctorNumberId { get; set; }

        // New field to store the hashed password
        public string PasswordHash { get; set; }
    }
}

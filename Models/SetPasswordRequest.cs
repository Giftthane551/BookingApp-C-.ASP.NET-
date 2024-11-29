namespace Booking.Models

{
    public class SetPasswordRequest
    {
        public string Password { get; set; }
        public int DoctorId { get; set; }
    }
}

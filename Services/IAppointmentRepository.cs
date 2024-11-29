namespace Booking.Services
{
    public interface IAppointmentRepository
    {
        Task AddAppointmentAsync(Appointment appointment);
        Task<List<Appointment>> GetAppointmentsAsync();
    }
}

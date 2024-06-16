using EventBookingShared.Dtos;

namespace EventBookingWebApp.Services;

public interface IAttendeeService
{
    Task<List<AttendeeDto>> GetAllAttendeesAsync();
    Task<AttendeeDto> GetAttendeeByIdAsync(int id);
    Task CreateAttendeeAsync(AttendeeDto attendee);
    Task UpdateAttendeeAsync(AttendeeDto attendee);
    Task DeleteAttendeeAsync(int id);
}
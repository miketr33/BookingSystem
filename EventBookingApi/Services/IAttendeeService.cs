using EventBookingApi.Models;

namespace EventBookingApi.Services;

public interface IAttendeeService
{
    Task CreateAttendee(Attendee attendee);
    Task<List<Attendee>> GetAttendees();
    Task<Attendee?> GetAttendeeById(int id);
    Task UpdateAttendee(Attendee attendee);
    Task DeleteAttendee(int id);
}
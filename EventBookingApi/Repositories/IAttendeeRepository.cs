using EventBookingApi.Models;

namespace EventBookingApi.Repositories;

public interface IAttendeeRepository
{
    Task CreateAttendee(Attendee? attendee);
    Task<List<Attendee>> GetAttendees();
    Task<Attendee?> GetAttendeeById(int attendeeId);
    Task UpdateAttendee(Attendee attendee);
    Task DeleteAttendee(int attendeeId);
}
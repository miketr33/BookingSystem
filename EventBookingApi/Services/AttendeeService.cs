using EventBookingApi.Models;
using EventBookingApi.Repositories;

namespace EventBookingApi.Services;

public class AttendeeService(IAttendeeRepository attendeeRepository) : IAttendeeService
{
    public async Task CreateAttendee(Attendee attendee)
    {
        await attendeeRepository.CreateAttendee(attendee);
    }

    public async Task<List<Attendee>> GetAttendees()
    {
        return await attendeeRepository.GetAttendees();
    }

    public async Task<Attendee?> GetAttendeeById(int id)
    {
        return await attendeeRepository.GetAttendeeById(id);
    }

    public async Task UpdateAttendee(Attendee attendee)
    {
        await attendeeRepository.UpdateAttendee(attendee);
    }

    public async Task DeleteAttendee(int id)
    {
        await attendeeRepository.DeleteAttendee(id);
    }
}
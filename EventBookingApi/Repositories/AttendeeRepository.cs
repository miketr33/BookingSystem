using EventBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBookingApi.Repositories;

public class AttendeeRepository(EventBookingDbContext context) : IAttendeeRepository
{
    public async Task CreateAttendee(Attendee? attendee)
    {
        if (attendee == null) return;
        context.Database.SetCommandTimeout(120);
        await context.Attendee.AddAsync(attendee);
        await context.SaveChangesAsync();
    }

    public async Task<List<Attendee>> GetAttendees()
    {
        return await context.Attendee.ToListAsync();
    }

    public async Task<Attendee?> GetAttendeeById(int id)
    {
        return await context.Attendee.FindAsync(id);
    }

    public async Task UpdateAttendee(Attendee activity)
    {
        context.Attendee.Update(activity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAttendee(int id)
    {
        var activityToDelete = await context.Attendee.FindAsync(id);
        if (activityToDelete != null)
        {
            context.Attendee.Remove(activityToDelete);
            await context.SaveChangesAsync();
        }
    }
}
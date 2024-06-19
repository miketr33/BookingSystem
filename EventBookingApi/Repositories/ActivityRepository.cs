using EventBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBookingApi.Repositories;

public class ActivityRepository(EventBookingDbContext context) : IActivityRepository
{
    public async Task CreateActivity(ActivityDetails? activity)
    {
        if (activity == null) return;
        context.Database.SetCommandTimeout(120);
        await context.ActivityDetails.AddAsync(activity);
        await context.SaveChangesAsync();
    }

    public async Task<List<ActivityDetails>> GetActivities()
    {
        return await context.ActivityDetails.ToListAsync();
    }

    public async Task<ActivityDetails?> GetActivityById(int id)
    {
        return await context.ActivityDetails.FindAsync(id);
    }

    public async Task UpdateActivity(ActivityDetails activityDetails)
    {
        context.ActivityDetails.Update(activityDetails);
        await context.SaveChangesAsync();
    }

    public async Task DeleteActivity(int id)
    {
        var activityToDelete = await context.ActivityDetails.FindAsync(id);
        if (activityToDelete != null)
        {
            context.ActivityDetails.Remove(activityToDelete);
            await context.SaveChangesAsync();
        }
    }
}
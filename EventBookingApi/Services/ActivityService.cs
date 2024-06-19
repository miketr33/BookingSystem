using EventBookingApi.Models;
using EventBookingApi.Repositories;

namespace EventBookingApi.Services;

public class ActivityService(IActivityRepository activityRepository) : IActivityService
{
    public async Task CreateActivity(ActivityDetails activityDetails)
    {
        await activityRepository.CreateActivity(activityDetails);
    }

    public async Task<List<ActivityDetails>> GetAllActivities()
    {
        var response = await activityRepository.GetActivities();
        return response ?? [];
    }

    public async Task<ActivityDetails?> GetActivityById(int id)
    {
        return await activityRepository.GetActivityById(id);
    }

    public async Task UpdateActivity(ActivityDetails activityDetails)
    {
        await activityRepository.UpdateActivity(activityDetails);
    }

    public async Task DeleteActivity(int id)
    {
        await activityRepository.DeleteActivity(id);
    }
}
using EventBookingApi.Models;

namespace EventBookingApi.Services;

public interface IActivityService
{
    Task CreateActivity(ActivityDetails activityDetails);
    Task<List<ActivityDetails?>> GetActivities();
    Task<ActivityDetails?> GetActivityById(int id);
    Task UpdateActivity(ActivityDetails activityDetails);
    Task DeleteActivity(int id);
}
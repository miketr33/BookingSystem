using EventBookingApi.Models;

namespace EventBookingApi.Repositories;

public interface IActivityRepository
{
    Task CreateActivity(ActivityDetails? activity);
    Task<List<ActivityDetails?>> GetActivities();
    Task<ActivityDetails?> GetActivityById(int activityId);
    Task UpdateActivity(ActivityDetails activityDetails);
    Task DeleteActivity(int activityId);
}
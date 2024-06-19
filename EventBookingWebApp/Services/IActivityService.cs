using EventBookingShared.Dtos;

namespace EventBookingWebApp.Services;

public interface IActivityService
{
    Task<List<ActivityDto>?> GetAllActivitiesAsync();
    Task<ActivityDto?> GetActivityByIdAsync(int id);
    Task DeleteActivityAsync(int? id);
    Task UpdateActivityAsync(ActivityDto activityDto);
    Task CreateNewActivityAsync(ActivityDto newActivity);
}
using EventBookingShared.Dtos;

namespace EventBookingWebApp.Services;

public interface IActivityService
{
    Task<List<ActivityDto>> GetAllActivitiesAsync();
    Task DeleteActivityAsync(int? id);
    Task UpdateActivityAsync(ActivityDto activityDto);
    Task CreateNewActivityAsync(ActivityDto newActivity);
}
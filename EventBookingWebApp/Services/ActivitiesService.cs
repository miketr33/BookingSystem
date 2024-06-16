using EventBookingShared.Dtos;

namespace EventBookingWebApp.Services;

public class ActivityService(HttpClient httpClient) : IActivityService
{
    private const string BaseUrl = "https://localhost:7200/";

    public async Task<List<ActivityDto>> GetAllActivitiesAsync()
    {
        try
        {
            return await httpClient.GetFromJsonAsync<List<ActivityDto>>($"{BaseUrl}activity");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            return null;
        }
    }

    public async Task DeleteActivityAsync(int? id)
    {
        try
        {
            await httpClient.DeleteAsync($"{BaseUrl}activity/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
    }

    public async Task UpdateActivityAsync(ActivityDto activityDto)
    {
        try
        {
            var url = $"{BaseUrl}activity/{activityDto.Id}";
            await httpClient.PutAsJsonAsync(url, activityDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
    }

    public async Task CreateNewActivityAsync(ActivityDto newActivity)
    {
        try
        {
            var url = $"{BaseUrl}activity";
            await httpClient.PostAsJsonAsync(url, newActivity);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
    }
}
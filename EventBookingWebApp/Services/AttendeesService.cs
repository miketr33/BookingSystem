using EventBookingShared.Dtos;

namespace EventBookingWebApp.Services
{

    public class AttendeeService(HttpClient httpClient) : IAttendeeService
    {
        private const string BaseUrl = "https://localhost:7200/attendee/";

        public async Task<List<AttendeeDto>?> GetAllAttendeesAsync()
        {
            return await httpClient.GetFromJsonAsync<List<AttendeeDto>>(BaseUrl);
        }

        public async Task<AttendeeDto?> GetAttendeeByIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<AttendeeDto>($"{BaseUrl}{id}");
        }

        public async Task CreateAttendeeAsync(AttendeeDto attendee)
        {
            await httpClient.PostAsJsonAsync(BaseUrl, attendee);
        }

        public async Task UpdateAttendeeAsync(AttendeeDto attendee)
        {
            await httpClient.PutAsJsonAsync($"{BaseUrl}{attendee.Id}", attendee);
        }

        public async Task DeleteAttendeeAsync(int id)
        {
            await httpClient.DeleteAsync($"{BaseUrl}{id}");
        }
    }

}

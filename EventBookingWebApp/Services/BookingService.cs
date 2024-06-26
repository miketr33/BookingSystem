﻿using EventBookingShared.Dtos;
using System.Net;

namespace EventBookingWebApp.Services
{
    public class BookingService(HttpClient httpClient, IActivityService activityService, IAttendeeService attendeeService) : IBookingService
    {
        private const string BaseUrl = "https://localhost:7200/booking/";
        public async Task<BookingDto?> CreateBooking(BookingDto bookingDto)
        {
            try
            {
                await attendeeService.GetAttendeeByIdAsync(bookingDto.AttendeeId);
                await activityService.GetActivityByIdAsync(bookingDto.ActivityId);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            var response = await httpClient.PostAsJsonAsync(BaseUrl, bookingDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BookingDto>();

        }

        public async Task<List<BookingDto>> GetAllBookings()
        {
            return await httpClient.GetFromJsonAsync<List<BookingDto>>(BaseUrl) ?? [];
        }

        public async Task<List<BookingDto>> GetBookingsByActivityId(int activityId)
        {
            return await httpClient.GetFromJsonAsync<List<BookingDto>>($"{BaseUrl}activity/{activityId}") ?? [];
        }

        public async Task<List<BookingDto>> GetBookingsByAttendeeId(int attendeeId)
        {
            return await httpClient.GetFromJsonAsync<List<BookingDto>>($"{BaseUrl}attendee/{attendeeId}") ?? [];
        }

        public async Task<BookingDto> GetBookingByAttendeeIdAndActivityId(int attendeeId, int activityId)
        {
            return await httpClient.GetFromJsonAsync<BookingDto>($"{BaseUrl}attendee/{attendeeId}/activity/{activityId}");
        }

        public async Task<BookingDto> GetBookingByBookingId(int bookingId)
        {
            return await httpClient.GetFromJsonAsync<BookingDto>($"{BaseUrl}{bookingId}");
        }

        public async Task UpdateBooking(BookingDto bookingDto)
        {
            var response = await httpClient.PutAsJsonAsync($"{BaseUrl}{bookingDto.Id}", bookingDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBooking(int bookingId)
        {
            var response = await httpClient.DeleteAsync($"{BaseUrl}{bookingId}");
            response.EnsureSuccessStatusCode();
        }
    }
}

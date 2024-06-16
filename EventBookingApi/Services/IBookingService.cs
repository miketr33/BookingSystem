using EventBookingApi.Models;

namespace EventBookingApi.Services;

public interface IBookingService
{
    Task CreateBooking(Booking booking);
    Task<List<Booking?>> GetBookingsByActivityId(int activityId);
    Task<List<Booking?>> GetBookingsByAttendeeId(int attendeeId);
    Task<Booking?> GetBookingByAttendeeIdAndActivityId(int attendeeId, int activityId);
    Task<List<Booking?>> GetAllBookings();
    Task<Booking?> GetBookingByBookingId(int id);
    Task UpdateBooking(Booking booking);
    Task DeleteBooking(int id);
}
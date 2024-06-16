using EventBookingApi.Models;

namespace EventBookingApi.Repositories;

public interface IBookingRepository
{
    Task CreateBooking(Booking? booking);
    Task<List<Booking?>> GetBookingsByActivityId(int activityId);
    Task<List<Booking?>> GetBookingsByAttendeeId(int attendeeId);
    Task<Booking?> GetBookingByAttendeeIdAndActivityId(int attendeeId, int activityId);
    Task<List<Booking?>> GetAllBookings();
    Task<Booking?> GetBookingByBookingId(int bookingId);
    Task UpdateBooking(Booking booking);
    Task DeleteBooking(int bookingId);
}
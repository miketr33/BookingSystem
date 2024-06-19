using EventBookingShared.Dtos;

namespace EventBookingWebApp.Services;

public interface IBookingService
{
    Task<BookingDto?> CreateBooking(BookingDto bookingDto);
    Task<List<BookingDto>> GetAllBookings();
    Task<List<BookingDto>> GetBookingsByActivityId(int activityId);
    Task<List<BookingDto>> GetBookingsByAttendeeId(int attendeeId);
    Task<BookingDto> GetBookingByAttendeeIdAndActivityId(int attendeeId, int activityId);
    Task<BookingDto> GetBookingByBookingId(int bookingId);
    Task UpdateBooking(BookingDto bookingDto);
    Task DeleteBooking(int bookingId);
}
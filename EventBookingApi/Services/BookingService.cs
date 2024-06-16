using EventBookingApi.Models;
using EventBookingApi.Repositories;

namespace EventBookingApi.Services;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    public async Task CreateBooking(Booking booking)
    {
        await bookingRepository.CreateBooking(booking);
    }

    public async Task<List<Booking?>> GetBookingsByActivityId(int activityId)
    {
        return await bookingRepository.GetBookingsByActivityId(activityId);
    }

    public async Task<List<Booking?>> GetBookingsByAttendeeId(int attendeeId)
    {
        return await bookingRepository.GetBookingsByAttendeeId(attendeeId);
    }

    public async Task<Booking?> GetBookingByAttendeeIdAndActivityId(int attendeeId, int activityId)
    {
        return await bookingRepository.GetBookingByAttendeeIdAndActivityId(attendeeId, activityId);
    }

    public async Task<List<Booking?>> GetAllBookings()
    {
        return await bookingRepository.GetAllBookings();
    }

    public async Task<Booking?> GetBookingByBookingId(int id)
    {
        return await bookingRepository.GetBookingByBookingId(id);
    }

    public async Task UpdateBooking(Booking booking)
    {
        await bookingRepository.UpdateBooking(booking);
    }

    public async Task DeleteBooking(int id)
    {
        await bookingRepository.DeleteBooking(id);
    }
}
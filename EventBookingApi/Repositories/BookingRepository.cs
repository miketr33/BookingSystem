using EventBookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBookingApi.Repositories;

public class BookingRepository(EventBookingDbContext context) : IBookingRepository
{
    public async Task CreateBooking(Booking? booking)
    {
        await context.Booking.AddAsync(booking);
        await context.SaveChangesAsync();
    }

    public async Task<List<Booking?>> GetBookingsByActivityId(int activityId)
    {
        return await context.Booking
            .Where(b => b != null && b.ActivityId == activityId)
            .ToListAsync();
    }

    public async Task<List<Booking?>> GetBookingsByAttendeeId(int attendeeId)
    {
        return await context.Booking
            .Where(b => b != null && b.AttendeeId == attendeeId)
            .ToListAsync();
    }

    public async Task<Booking?> GetBookingByAttendeeIdAndActivityId(int attendeeId, int activityId)
    {
        return await context.Booking
            .FirstOrDefaultAsync(b => b != null && b.AttendeeId == attendeeId && b.ActivityId == activityId);
    }

    public async Task<List<Booking?>> GetAllBookings()
    {
        return await context.Booking.ToListAsync();
    }

    public async Task<Booking?> GetBookingByBookingId(int id)
    {
        return await context.Booking.FirstOrDefaultAsync(b => b != null && b.Id == id);
    }

    public async Task UpdateBooking(Booking booking)
    {
        context.Booking.Update(booking);
        await context.SaveChangesAsync();
    }

    public async Task DeleteBooking(int id)
    {
        var bookingToDelete = await context.Booking.FindAsync(id);
        if (bookingToDelete != null)
        {
            context.Booking.Remove(bookingToDelete);
            await context.SaveChangesAsync();
        }
    }
}
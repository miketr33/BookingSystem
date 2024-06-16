using EventBookingApi.Models;

namespace EventBookingShared.Dtos;

public class BookingDto
{
    public int Id { get; set; }

    public int ActivityId { get; set; }

    public ActivityDetails? ActivityDetails { get; set; }

    public int AttendeeId { get; set; }

    public Attendee? Attendee { get; set; }

    public bool Attended { get; set; }
}
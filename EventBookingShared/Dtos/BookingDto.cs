using EventBookingApi.Models;
using System.ComponentModel.DataAnnotations;

namespace EventBookingShared.Dtos;

public class BookingDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Activity Id is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Activity Id must be greater than 0.")]
    public int ActivityId { get; set; }

    public ActivityDetails? ActivityDetails { get; set; }

    [Required(ErrorMessage = "Attendee Id is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Attendee Id must be greater than 0.")]
    public int AttendeeId { get; set; }

    public Attendee? Attendee { get; set; }

    [Required(ErrorMessage = "Attended status is required.")]
    public bool Attended { get; set; }
}
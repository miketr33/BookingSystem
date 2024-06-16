using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBookingApi.Models;

public class Booking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public int ActivityId { get; set; }

    [ForeignKey("ActivityId")] public ActivityDetails? ActivityDetails { get; set; }

    [Required] public int AttendeeId { get; set; }

    [ForeignKey("AttendeeId")] public Attendee? Attendee { get; set; }

    [Required] public bool Attended { get; set; }
}
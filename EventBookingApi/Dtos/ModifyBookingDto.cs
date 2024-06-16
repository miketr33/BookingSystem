namespace EventBookingApi.Dtos;

public class ModifyBookingDto
{
    public int ActivityId { get; set; }

    public int AttendeeId { get; set; }

    public bool? Attended { get; set; }
}
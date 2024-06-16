namespace EventBookingApi.Dtos;

public class ModifiedAttendeeDto
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string? Postcode { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}
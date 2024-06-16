namespace EventBookingApi.Dtos;

public class ModifyActivityDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string? Postcode { get; set; }

    public DateTime ActivityStart { get; set; }

    public DateTime ActivityEnd { get; set; }
}
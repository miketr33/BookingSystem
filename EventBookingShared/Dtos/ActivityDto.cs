using System.ComponentModel.DataAnnotations;

namespace EventBookingShared.Dtos;

public class ActivityDto
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(2000, ErrorMessage = "Description length can't be more than 2000 characters")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Address Line 1 is required")]
    [StringLength(100, ErrorMessage = "Address Line 1 length can't be more than 100 characters")]
    public string? AddressLine1 { get; set; }

    [StringLength(100, ErrorMessage = "Address Line 2 length can't be more than 100 characters")]
    public string? AddressLine2 { get; set; }

    [StringLength(100, ErrorMessage = "Address Line 3 length can't be more than 100 characters")]
    public string? AddressLine3 { get; set; }

    [Required(ErrorMessage = "Postcode is required")]
    [StringLength(8, ErrorMessage = "Postcode length can't be more than 8 characters")]
    public string? Postcode { get; set; }

    [Required(ErrorMessage = "Activity start date is required")]
    [FutureDate(ErrorMessage = "Start date must be in the future.")]
    public DateTime ActivityStart { get; set; }

    [Required(ErrorMessage = "Activity end date is required")]
    [FutureDate(ErrorMessage = "End date must be in the future.")]
    public DateTime ActivityEnd { get; set; }
}

public class FutureDateAttribute : ValidationAttribute
{
    public FutureDateAttribute()
    {
        ErrorMessage = "The date must be in the future.";
    }

    public override bool IsValid(object value)
    {
        if (value is DateTime dateTime)
        {
            return dateTime > DateTime.Now;
        }
        return false;
    }
}
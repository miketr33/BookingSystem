using System.ComponentModel.DataAnnotations;

namespace EventBookingShared.Dtos;

public class AttendeeDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(100, ErrorMessage = "First Name can't be longer than 100 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(100, ErrorMessage = "Last Name can't be longer than 100 characters.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Address Line 1 is required.")]
    [StringLength(100, ErrorMessage = "Address Line 1 can't be longer than 100 characters.")]
    public string AddressLine1 { get; set; }

    [StringLength(100, ErrorMessage = "Address Line 2 can't be longer than 100 characters.")]
    public string? AddressLine2 { get; set; }

    [StringLength(100, ErrorMessage = "Address Line 3 can't be longer than 100 characters.")]
    public string? AddressLine3 { get; set; }

    [Required(ErrorMessage = "Postcode is required.")]
    [StringLength(8, ErrorMessage = "Postcode can't be longer than 8 characters.")]
    public string Postcode { get; set; }

    [Required(ErrorMessage = "Phone is required.")]
    [StringLength(20, ErrorMessage = "Phone number can't be longer than 20 characters.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    public DateTime DateOfBirth { get; set; }
}
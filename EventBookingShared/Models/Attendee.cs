using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBookingApi.Models;

public class Attendee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [StringLength(50)] public string FirstName { get; set; }

    [Required] [StringLength(50)] public string LastName { get; set; }

    [StringLength(100)] public string AddressLine1 { get; set; }

    [StringLength(100)] public string AddressLine2 { get; set; }

    [StringLength(100)] public string AddressLine3 { get; set; }

    [StringLength(8)] public string Postcode { get; set; }

    [StringLength(13)] public string Phone { get; set; }

    [Required] [StringLength(200)] public string Email { get; set; }

    [Required] public DateTime DateOfBirth { get; set; }
}
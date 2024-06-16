using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBookingApi.Models;

public class ActivityDetails
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [StringLength(100)] public string Name { get; set; }

    [Required] [StringLength(2000)] public string Description { get; set; }

    [Required] [StringLength(100)] public string AddressLine1 { get; set; }

    [StringLength(100)] public string AddressLine2 { get; set; }

    [StringLength(100)] public string AddressLine3 { get; set; }

    [Required] [StringLength(8)] public string Postcode { get; set; }

    [Required] public DateTime ActivityStart { get; set; }

    [Required] public DateTime ActivityEnd { get; set; }
}
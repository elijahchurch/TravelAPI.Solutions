using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Models
{
  public class Destination
  {
    public int DestinationId {get; set; }
    [Required]
    [StringLength(30)]
    public string CityName { get; set; }
    [Required]
    public string Country { get; set; }
    public string Review { get; set; }
    [Required]
    [Range(0, 10, ErrorMessage = "Must be 1 to 10 number")]
    public int Rating { get; set; }
  }
}

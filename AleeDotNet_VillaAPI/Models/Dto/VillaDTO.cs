using System.ComponentModel.DataAnnotations;

namespace Alee_VillaAPI.Models.Dto;

// DTOs provide a wrapper between the entity or the database model and what is being exposed from the API
public class VillaDTO
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }

    public int Occupancy { get; set; }
    public int Sqft { get; set; } // square feet^2
    
}
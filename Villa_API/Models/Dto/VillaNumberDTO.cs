using System.ComponentModel.DataAnnotations;

namespace Alee_VillaAPI.Models.Dto;

public class VillaNumberDTO
{
    [Required] public int VillaNo { get; set; }
    [Required] public int VillaID { get; set; }

    public string SpecialDetails { get; set; }
}
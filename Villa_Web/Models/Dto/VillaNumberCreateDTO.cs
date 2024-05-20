using System.ComponentModel.DataAnnotations;

namespace AleeDotNet_VillaWeb.Models.Dto;

public class VillaNumberCreateDTO
{
    [Required] public int VillaNo { get; set; }
    [Required] public int VillaID { get; set; }

    public string SpecialDetails { get; set; }
}
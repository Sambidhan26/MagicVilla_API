using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.Dto
{
    public class VillaNumberUpdateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        //[Required]
        //public int VillaID { get; set; }
        //public VillaDTO villaDTO { get; set; }
        public string SpecialDetails { get; set; }
    }
}

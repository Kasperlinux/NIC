using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class VillageViewModel
    {
        [Column("State_Code")]
        public int StateCode { get; set; }

        [Column("District_Code")]
        public int DistrictCode { get; set; }

        [Column("Block_Code")]
        public int BlockCode { get; set; }

        [Key]
        [Column("Village_Code")]
        public int VillageCode { get; set; }

        [Column("Village_Name")]
        [StringLength(60)]
        public string VillageName { get; set; } = null!;
    }
}

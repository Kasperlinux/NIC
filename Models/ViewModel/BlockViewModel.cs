using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class BlockViewModel
    {
        [Column("State_Code")]
        public int StateCode { get; set; }

        [Column("District_Code")]
        public int DistrictCode { get; set; }

        [Key]
        [Column("Block_Code")]
        public int BlockCode { get; set; }

        [Column("Block_Name")]
        [StringLength(60)]
        public string BlockName { get; set; } = null!;
    }
}

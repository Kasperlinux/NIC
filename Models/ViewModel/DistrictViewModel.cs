using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class DistrictViewModel
    {
        [Column("State_Code")]
        public int StateCode { get; set; }

        [Key]
        [Column("District_Code")]
        public int DistrictCode { get; set; }

        [Column("District_Name")]
        [StringLength(60)]
        public string DistrictName { get; set; } = null!;
    }
}

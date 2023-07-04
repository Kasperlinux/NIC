using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class ScreeningCenterViewModel
    {
        public int? ScreeningCentre { get; set; }

        [Column("ScreeningCentre_Name")]
        [StringLength(20)]
        public string? ScreeningCentreName { get; set; }

        public int? ApplicationType { get; set; }
    }
}

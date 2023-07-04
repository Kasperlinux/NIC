using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class GenderViewModel
    {
        [Key]
        [StringLength(1)]
        public string Gender { get; set; } = null!;

        [Column("Gender_Desc")]
        [StringLength(20)]
        public string? GenderDesc { get; set; }
    }
}

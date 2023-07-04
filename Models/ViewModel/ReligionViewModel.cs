using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class ReligionViewModel
    {
        [Key]
        public int Religion { get; set; }

        [Column("Religion_Desc")]
        [StringLength(20)]
        public string? ReligionDesc { get; set; }
    }
}

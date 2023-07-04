using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class NationalityViewModel
    {
        public int? Nationality { get; set; }

        [Column("Nationality_Name")]
        [StringLength(20)]
        public string? NationalityName { get; set; }
    }
}

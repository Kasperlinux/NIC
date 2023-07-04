using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class CategoryViewModel
    {
        public int? Category { get; set; }

        [Column("Category_Desc")]
        [StringLength(20)]
        public string? CategoryDesc { get; set; }
    }
}

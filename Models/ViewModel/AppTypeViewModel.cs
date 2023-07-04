using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class AppTypeViewModel
    {
        [Key]
        public int ApplicationType { get; set; }

        [Column("Application_Desc")]
        [StringLength(60)]
        public string ApplicationDesc { get; set; } = null!;
    }
}

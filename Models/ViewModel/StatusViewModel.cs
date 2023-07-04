using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class StatusViewModel
    {
        [Key]
        public int ApplicationStatus { get; set; }

        [Column("ApplicationStatus_Desc")]
        [StringLength(20)]
        public string? ApplicationStatusDesc { get; set; }
    }
}

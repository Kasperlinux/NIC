using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class CoursesMbbsViewModel
    {
        [Column("MBBS_CourseCode")]
        public int MbbsCourseCode { get; set; }

        [Column("MBBS_CouseName")]
        [StringLength(100)]
        public string? MbbsCouseName { get; set; }
    }
}

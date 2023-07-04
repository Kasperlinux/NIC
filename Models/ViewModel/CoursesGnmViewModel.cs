using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class CoursesGnmViewModel
    {
        [Column("GNM_CourseCode")]
        public int? GnmCourseCode { get; set; }

        [Column("GMN_Couse")]
        [StringLength(100)]
        public string? GmnCouse { get; set; }
    }
}

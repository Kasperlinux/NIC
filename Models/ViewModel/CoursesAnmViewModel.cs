using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class CoursesAnmViewModel
    {
        [Column("ANM_CourseCode")]
        public int? AnmCourseCode { get; set; }

        [Column("AMN_Course")]
        [StringLength(100)]
        public string? AmnCourse { get; set; }
    }
}

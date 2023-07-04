using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class AlliedCoursesViewModel
    {
        [Column("AC_CourseCode")]
        public int AcCourseCode { get; set; }

        [Column("AC_CourseName")]
        [StringLength(100)]
        public string? AcCourseName { get; set; }
    }
}

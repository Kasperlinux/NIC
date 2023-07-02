using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Keyless]
[Table("mCourses_AlliedCourses")]
public partial class MCoursesAlliedCourse
{
    [Column("AC_CourseCode")]
    public int AcCourseCode { get; set; }

    [Column("AC_CourseName")]
    [StringLength(100)]
    public string? AcCourseName { get; set; }
}

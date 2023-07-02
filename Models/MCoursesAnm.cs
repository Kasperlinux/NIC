using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Keyless]
[Table("mCourses_ANM")]
public partial class MCoursesAnm
{
    [Column("ANM_CourseCode")]
    public int? AnmCourseCode { get; set; }

    [Column("AMN_Course")]
    [StringLength(100)]
    public string? AmnCourse { get; set; }
}

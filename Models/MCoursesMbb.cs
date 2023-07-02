using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Keyless]
[Table("mCourses_MBBS")]
public partial class MCoursesMbb
{
    [Column("MBBS_CourseCode")]
    public int MbbsCourseCode { get; set; }

    [Column("MBBS_CouseName")]
    [StringLength(100)]
    public string? MbbsCouseName { get; set; }
}

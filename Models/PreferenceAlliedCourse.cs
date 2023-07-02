using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Keyless]
[Table("preference_AlliedCourses")]
public partial class PreferenceAlliedCourse
{
    [Column("Applicant_Id")]
    public int? ApplicantId { get; set; }

    [Column("AC_CourseCode")]
    public int? AcCourseCode { get; set; }

    public int? Preference { get; set; }
}

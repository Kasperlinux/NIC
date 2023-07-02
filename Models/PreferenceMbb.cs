using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Keyless]
[Table("preference_MBBS")]
public partial class PreferenceMbb
{
    [Column("Applicant_Id")]
    public int? ApplicantId { get; set; }

    [Column("MBBS_CourseCode")]
    public int? MbbsCourseCode { get; set; }

    public int? Preference { get; set; }
}

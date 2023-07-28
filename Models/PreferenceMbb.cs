using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

<<<<<<< HEAD

[Table("preference_MBBS")]
public partial class PreferenceMbb
{
    [Key] // Add this annotation to specify the primary key
    [Column("Preference_Id")] // Assuming the primary key column name is "Preference_Id"
    public int PreferenceId { get; set; }
=======
[Keyless]
[Table("preference_MBBS")]
public partial class PreferenceMbb
{
>>>>>>> master
    [Column("Applicant_Id")]
    public int? ApplicantId { get; set; }

    [Column("MBBS_CourseCode")]
    public int? MbbsCourseCode { get; set; }

    public int? Preference { get; set; }
}

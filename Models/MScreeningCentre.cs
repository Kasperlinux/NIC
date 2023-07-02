using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Keyless]
[Table("mScreeningCentre")]
public partial class MScreeningCentre
{
    public int? ScreeningCentre { get; set; }

    [Column("ScreeningCentre_Name")]
    [StringLength(20)]
    public string? ScreeningCentreName { get; set; }

    public int? ApplicationType { get; set; }
}

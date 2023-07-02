using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Keyless]
[Table("mApplicationType")]
public partial class MApplicationType
{
    public int ApplicationType { get; set; }

    [Column("Application_Desc")]
    [StringLength(60)]
    public string ApplicationDesc { get; set; } = null!;
}

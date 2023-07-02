using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Keyless]
[Table("mCategory")]
public partial class MCategory
{
    public int? Category { get; set; }

    [Column("Category_Desc")]
    [StringLength(20)]
    public string? CategoryDesc { get; set; }
}

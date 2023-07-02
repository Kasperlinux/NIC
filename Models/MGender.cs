using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Table("mGender")]
public partial class MGender
{
    [Key]
    [StringLength(1)]
    public string Gender { get; set; } = null!;

    [Column("Gender_Desc")]
    [StringLength(20)]
    public string? GenderDesc { get; set; }
}

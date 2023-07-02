using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Table("mReligion")]
public partial class MReligion
{
    [Key]
    public int Religion { get; set; }

    [Column("Religion_Desc")]
    [StringLength(20)]
    public string? ReligionDesc { get; set; }
}

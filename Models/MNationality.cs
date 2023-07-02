using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Keyless]
[Table("mNationality")]
public partial class MNationality
{
    public int? Nationality { get; set; }

    [Column("Nationality_Name")]
    [StringLength(20)]
    public string? NationalityName { get; set; }
}

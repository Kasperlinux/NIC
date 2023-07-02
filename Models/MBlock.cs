using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Table("mBlocks")]
public partial class MBlock
{
    [Column("State_Code")]
    public int StateCode { get; set; }

    [Column("District_Code")]
    public int DistrictCode { get; set; }

    [Key]
    [Column("Block_Code")]
    public int BlockCode { get; set; }

    [Column("Block_Name")]
    [StringLength(60)]
    public string BlockName { get; set; } = null!;
}

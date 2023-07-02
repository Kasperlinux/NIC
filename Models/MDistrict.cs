using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

[Table("mDistricts")]
public partial class MDistrict
{
    [Column("State_Code")]
    public int StateCode { get; set; }

    [Key]
    [Column("District_Code")]
    public int DistrictCode { get; set; }

    [Column("District_Name")]
    [StringLength(60)]
    public string DistrictName { get; set; } = null!;
}

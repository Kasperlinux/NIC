using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NIC.Models;

<<<<<<< HEAD

public partial class AgeEligibilityCriterion
{
    [Key]
=======
[Keyless]
public partial class AgeEligibilityCriterion
{
>>>>>>> master
    [Column("Session_Code")]
    public int? SessionCode { get; set; }

    public int? Category { get; set; }

    [Column("AgeLimit_Lower")]
    public int? AgeLimitLower { get; set; }

    [Column("AgeLimit_Upper")]
    public int? AgeLimitUpper { get; set; }
}

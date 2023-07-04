using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class SessionViewModel
    {
        [Column("Session_Code")]
        [StringLength(9)]
        [Unicode(false)]
        public string SessionCode { get; set; } = null!;

        [Column("State_Code")]
        public int? StateCode { get; set; }

        public int? ApplicationType { get; set; }

        [StringLength(7)]
        public string? AcademicSession { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateAsOnforAgeCutOff { get; set; }

        public byte[]? Advertisement { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string? AdvNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? AdvtDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastDateForApplication { get; set; }
    }
}

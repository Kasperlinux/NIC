using System.ComponentModel.DataAnnotations.Schema;

namespace NIC.Models.ViewModel
{
    public class AgeCriteriaViewModel
    {
        [Column("Session_Code")]
        public int? SessionCode { get; set; }

        public int? Category { get; set; }

        [Column("AgeLimit_Lower")]
        public int? AgeLimitLower { get; set; }

        [Column("AgeLimit_Upper")]
        public int? AgeLimitUpper { get; set; }
    }
}

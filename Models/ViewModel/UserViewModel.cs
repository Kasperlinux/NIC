using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class UserViewModel
    {
        [Column("User_Id")]
        public int UserId { get; set; }

        [Column("User_DisplayName")]
        [StringLength(20)]
        public string? UserDisplayName { get; set; }

        [Column("User_eMail")]
        [StringLength(50)]
        public string? UserEMail { get; set; }

        [Column("User_mobile")]
        [StringLength(10)]
        public string? UserMobile { get; set; }

        [Column("User_Password")]
        [StringLength(256)]
        public string? UserPassword { get; set; }

        [Column("Created_Date", TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [Column("Last_Login", TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }

        [Column("Last_LoginIP")]
        [StringLength(20)]
        public string? LastLoginIp { get; set; }

        [Column("Login_Attemps")]
        public int? LoginAttemps { get; set; }

        [Column("User_Category")]
        [StringLength(3)]
        public string? UserCategory { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class AddStateViewModel
    {

        [Column("State_Code")]
        public int StateCode { get; set; }

        [Column("State_Name")]
        [StringLength(60)]
        public string StateName { get; set; } = null!;
    }
}

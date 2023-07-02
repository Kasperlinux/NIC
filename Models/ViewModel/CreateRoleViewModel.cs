using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}

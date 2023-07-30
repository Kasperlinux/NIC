using System.ComponentModel.DataAnnotations;

namespace NIC.Models.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage = "Passwrod and Confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

<<<<<<< HEAD
        public string? City { get; set; }
=======
        public string City { get; set; }
>>>>>>> master
    }
}

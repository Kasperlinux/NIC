using Microsoft.AspNetCore.Identity;

namespace NIC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}

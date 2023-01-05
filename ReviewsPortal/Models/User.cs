using Microsoft.AspNetCore.Identity;

namespace ReviewsPortal.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}

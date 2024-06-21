using Microsoft.AspNetCore.Identity;

namespace MarketAPI.Entities
{
    public class AppRole : IdentityRole<int>
    {

        public ICollection<AppUserRoles> UserRoles { get; set; }
    }
}
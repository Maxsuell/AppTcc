using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MarketAPI.Entities
{
    public class AppUser : IdentityUser<int>
    {        
        public string Number { get; set; }
        public DateTime DateOfB { get; set; }
        public string CEP { get; set; }

        public ICollection<AppUserRoles> UserRoles { get; set; }

        public static implicit operator AppUser(Task<AppUser> v)
        {
            throw new NotImplementedException();
        }

    }
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MarketAPI.Entities
{
    public class AppUserRoles : IdentityUserRole<int>
    {        
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
        public string Number { get; set; }
        
        public int CNPJ { get; set; }

        public int? IdStorage { get; set; }
        public Storage Storage { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;


namespace MarketAPI.Entities
{
    public class Storage
    {
        [Key]
        public int IdStorage { get; set; }

        public int IdClient { get; set; }
    
        public AppUserRoles Client { get; set; }
        
        public ICollection<Produto> Produto { get; set; }
        
        
    }
}
using System.ComponentModel.DataAnnotations;

namespace MarketAPI.Entities
{
    public class Services
    {
        [Key]
        public int IdServices { get; set; }
        public int IdClient { get; set; }
        public AppUserRoles Client { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
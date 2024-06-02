namespace MarketAPI.Entities
{
    public class Storage
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int IdClient { get; set; }
        public ICollection<Produto> Produto { get; set; }
        
        
    }
}
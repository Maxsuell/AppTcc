namespace MarketAPI.DTOs
{
    public class StorageDtos
    {
        public int IdStorage { get; set; }
        public int IdClient { get; set; }
    
        public ICollection<ProdutoDtos> Produto { get; set; }
        
        public ClientDtos ClientDtos { get; set; }
    }
}
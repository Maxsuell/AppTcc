namespace MarketAPI.DTOs
{
    public class StorageDtos
    {
        public int Id { get; set; }
    
        public ICollection<ProdutoDtos> Produto { get; set; }
        
        
    }
}
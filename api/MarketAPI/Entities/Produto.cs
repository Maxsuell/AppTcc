using System.ComponentModel.DataAnnotations;

namespace MarketAPI.Entities
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public string NameProduto { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Qnt { get; set; }
        
        public int IdStorage { get; set; }
        public Storage Storage { get; set; }
        
    }
}
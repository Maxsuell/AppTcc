using System.ComponentModel.DataAnnotations;

namespace MarketAPI.DTOs
{
    public class ClientDtos
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NameFantasy { get; set; }        
        public string Number { get; set; }
        [Required]
        public int CNPJ { get; set; }
    }
}
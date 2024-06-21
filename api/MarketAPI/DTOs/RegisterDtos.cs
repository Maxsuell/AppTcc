using System.ComponentModel.DataAnnotations;

namespace MarketAPI.DTOs
{
    public class RegisterDtos
    {       
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
        public int CNPJ { get; set; }
    }
}
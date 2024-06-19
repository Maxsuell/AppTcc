namespace MarketAPI.Entities
{
    public class Cliente
    {
        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }
        public int CNPJ { get; set; }
        public string SenhaHash { get; set; }
        public string SenhaSalt { get; set; }
    }
}
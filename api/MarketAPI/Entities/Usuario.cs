namespace MarketAPI.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }
        public DateTime DataNasc { get; set; }
        public string CEP { get; set; }
        public string SenhaHash { get; set; }
        public string SenhaSalt { get; set; }
    }
}
namespace MarketAPI.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameFantasy { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int CNPJ { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
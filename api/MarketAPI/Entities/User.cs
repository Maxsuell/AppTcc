namespace MarketAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string NameUser { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public DateTime DateOfB { get; set; }
        public string CEP { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
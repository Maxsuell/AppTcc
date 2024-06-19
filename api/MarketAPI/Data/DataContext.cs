using MarketAPI.Entities;
using Microsoft.EntityFrameworkCore;



namespace MarketAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options){}

        public DbSet<User> User { get; set; }

        public DbSet<Client> Client { get; set; }


    }

}
using MarketAPI.Entities;
using Microsoft.EntityFrameworkCore;



namespace MarketAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {            
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Cliente> Cliente { get; set; }


    }

}
using MarketAPI.Entities;
using Microsoft.EntityFrameworkCore;



namespace MarketAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options){}

        public DbSet<User> User { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<Produto> Produto {get; set;}

        public DbSet<Services> Services { get; set; }

        public DbSet<Storage> Storage { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Storage>()
            .HasOne(s => s.Client)
            .WithMany()
            .HasForeignKey(st => st.IdClient)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Services>()
            .HasOne(s => s.Client)
            .WithMany()
            .HasForeignKey(st => st.IdClient)
            .OnDelete(DeleteBehavior.Cascade);
    }

    }

}
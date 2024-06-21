using MarketAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace MarketAPI.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
      IdentityUserClaim<int>,AppUserRoles,
       IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options): base(options){}
        public DbSet<Produto> Produto {get; set;}

        public DbSet<Services> Services { get; set; }

        public DbSet<Storage> Storage { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
       

        builder.Entity<Storage>()
                .HasMany(s => s.Produto)
                .WithOne(p => p.Storage)
                .HasForeignKey(p => p.IdStorage)
                .OnDelete(DeleteBehavior.Cascade);


        builder.Entity<Storage>()
            .HasOne(s => s.Client)
            .WithOne(c => c.Storage)
            .HasForeignKey<AppUserRoles>(c => c.IdStorage)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired();

        builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId)
            .IsRequired();
            


            
         base.OnModelCreating(builder);    
    }

    }

}
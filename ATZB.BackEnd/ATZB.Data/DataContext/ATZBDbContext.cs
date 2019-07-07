using Microsoft.EntityFrameworkCore;
using ATZB.Domain;

namespace ATZB.Data
{
    public class ATZBDbContext:DbContext
    {
        public DbSet<ATZBOrder> Orders { get; set; }

        public DbSet<ATZBUser> Users { get; set; }

        public DbSet<ATZBOffert> Offerts { get; set; }

        public DbSet<ATZBUserOffert> UserOfferts { get; set; }

        public DbSet<ATZBUserOrder> UserOrders { get; set; }

        public ATZBDbContext(DbContextOptions<ATZBDbContext> options) :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<ATZBUserOffert>()
                .HasKey(x => new { x.OffertId, x.UserId });

            model.Entity<ATZBUserOffert>()
                .HasOne(x => x.User)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.UserId);

            model.Entity<ATZBUserOffert>()
                .HasOne(x => x.Offert)
                .WithOne(x => x.User);

            model.Entity<ATZBUserOrder>()
                .HasKey(x => new { x.UserId, x.OrderId });

            model.Entity<ATZBUserOrder>()
                .HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);

            model.Entity<ATZBUserOrder>()
                .HasOne(x => x.Order)
                .WithOne(x => x.User);

            model.Entity<ATZBOffert>()
                .Property(x => x.Price)
                .HasColumnType("decimal(13, 2)");

            model.Entity<ATZBOrder>()
                .Property(x => x.PriceTo)
                .HasColumnType("decimal(13, 2)");
        }
    }
}

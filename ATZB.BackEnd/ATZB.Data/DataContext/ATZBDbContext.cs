namespace ATZB.Data.DataContext
{
    using ATZB.Domain;
    using ATZB.Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class ATZBDbContext : DbContext
    {
        public DbSet<ATZBUser> Users { get; set; }

        public DbSet<ATZBOrder> Orders { get; set; }

        public DbSet<ATZBOffert> Offers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Image> Images { get; set; }

        public ATZBDbContext(DbContextOptions<ATZBDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<ATZBUser>()
                .HasOne(x => x.Company)
                .WithOne(x => x.User)
                .HasForeignKey<ATZBUser>(x => x.CompanyId);

            model.Entity<Company>()
                .HasOne(x => x.User)
                .WithOne(x => x.Company)
                .HasForeignKey<Company>(x => x.UserId);

            model.Entity<ATZBOffert>()
                .HasOne(x => x.User)
                .WithMany(x => x.Offers)
                .HasForeignKey(x => x.UserId);

            model.Entity<ATZBOrder>()
                .HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);

            model.Entity<Image>()
                .HasOne(x => x.User)
                .WithMany(x => x.ImagesLinks)
                .HasForeignKey(x => x.UserId);

            model.Entity<ATZBOffert>()
                .Property(x => x.Price)
                .HasColumnType("decimal(13, 2)");

            model.Entity<ATZBOrder>()
                .Property(x => x.PriceTo)
                .HasColumnType("decimal(13, 2)");
        }
    }
}

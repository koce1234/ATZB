using ATZB.Domain;
using ATZB.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ATZB.Data.DataContext
{
    public class ATZBDbContext:DbContext
    {
        public DbSet<ATZBOrder> Orders { get; set; }

        public DbSet<ATZBUser> Users { get; set; }

        public DbSet<ATZBOffert> Offerts { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<TypeSpecial> TypeOfSpecials { get; set; }

       
        public ATZBDbContext(DbContextOptions<ATZBDbContext> options) :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
                       model.Entity<ATZBOffert>()
                .Property(x => x.Price)
                .HasColumnType("decimal(13, 2)");

            model.Entity<ATZBOrder>()
                .Property(x => x.PriceTo)
                .HasColumnType("decimal(13, 2)");
        }
    }
}

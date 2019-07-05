using ATZB.Domain;
using Microsoft.EntityFrameworkCore;

namespace ATZB.Data
{
    public class ATZBDbContext:DbContext
    {
        public DbSet<ATZBOrder> Orders { get; set; }

        public DbSet<ATZBUser> Users { get; set; }

        public DbSet<ATZBOffert> Offerts { get; set; }

        public DbSet<ATZBUserOffert> UserOfferts { get; set; }

        public DbSet<ATZBUserOrder> UserOrders { get; set; }

        public ATZBDbContext(DbContextOptions<ATZBDbContext> options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ATZBDb;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }
        

    }
}

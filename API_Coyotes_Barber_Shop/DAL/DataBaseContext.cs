using API_Coyotes_Barber_Shop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Coyotes_Barber_Shop.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Barber>().HasIndex(b => b.Name).IsUnique();
            modelBuilder.Entity<Service>().HasIndex(s => s.Name).IsUnique();
        }


        #region

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Service> Services { get; set; }


        #endregion

    }
}

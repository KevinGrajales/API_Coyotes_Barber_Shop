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

            //SERVICE RELATIONSHIP BY APPOINTMENT
            modelBuilder.Entity<Cita>()
                 .HasOne(a => a.Service)
                 .WithMany()
                 .HasForeignKey(a => a.ServiceId);

            //CUSTOMER RELATIONSHIP BY APPOINTMENT
            modelBuilder.Entity<Cita>()
                .HasOne(a => a.Customer)
                .WithMany()
                .HasForeignKey(a => a.CustomerId);


            //BARBER RELATIONSHIP BY APPOINTMENT
            modelBuilder.Entity<Cita>()
                .HasOne(a => a.Barber)
                .WithMany()
                .HasForeignKey(a => a.BarberId);

            // RELATIONSHIPS FOR REVIEW
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Service) // Relación con Service
                .WithMany()
                .HasForeignKey(r => r.ServiceId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer) // Relación con Customer
                .WithMany()
                .HasForeignKey(r => r.CustomerId);
        }


        #region

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Cita> Cita { get; set; }

        public DbSet<Review> Reviews { get; set; }

        #endregion

    }
}

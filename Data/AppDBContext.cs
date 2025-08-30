using Avancerad_Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Avancerad_Lab1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Seating> Seatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, UserName = "admin", PasswordHash = "$2a$11$OXFBTjx.tGgfWLD9tPleje9QW4IA/hE6ccpyevXL4aJ8NoZMhBE5a" }
            );
        }
    }
}

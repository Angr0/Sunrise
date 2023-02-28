 using Microsoft.EntityFrameworkCore;
 using Sunrise.Models;

namespace Sunrise
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=.\\SQLExpress;Database=sunrisedb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Addition> Additions { get; set; } 
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDto> UsersDto { get; set; }
    }
}

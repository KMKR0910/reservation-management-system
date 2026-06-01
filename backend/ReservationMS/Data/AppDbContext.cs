using Microsoft.EntityFrameworkCore;
using ReservationMS.Models;

namespace ReservationMS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }

    }
}
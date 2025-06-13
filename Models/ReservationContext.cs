using Microsoft.EntityFrameworkCore;
using ReservationSystem2022.Models;

namespace ReservationSystem2022.Models
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options)
            : base(options)
        {

        }
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        // Reservations and users removed


    }
}
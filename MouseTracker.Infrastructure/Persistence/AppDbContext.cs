using Microsoft.EntityFrameworkCore;
using MouseTracker.Domain.Entities;

namespace MouseTracker.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<MouseMovement> MouseMovements { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}

using Microsoft.EntityFrameworkCore;
using MyApi.Models; // Sørg for at dette er riktig!

namespace MyApi.Data // Sørg for at namespace matcher det som brukes i Program.cs!
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

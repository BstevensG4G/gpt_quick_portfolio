using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    // Constructor that accepts DbContextOptions
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSet property for Posts
    public DbSet<Post> Posts { get; set; }
}

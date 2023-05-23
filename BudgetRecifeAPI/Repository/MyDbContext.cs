using Microsoft.EntityFrameworkCore;
using Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Your entity configurations and other model definitions
        base.OnModelCreating(modelBuilder);
    }

    // DbSet properties representing your database tables
    public DbSet<Budget> Orcamentos { get; set; }
}
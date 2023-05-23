using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Globalization;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    // DbSet properties representing your database tables
    public DbSet<Budget> Budgets { get; set; }

    public void SeedDatabase(string CsvPath)
    {
        if (!(this.Budgets.Count() > 0))
        {
            using var reader = new StreamReader(CsvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Budget>();

            this.BulkInsert(records);
        }
    }
}
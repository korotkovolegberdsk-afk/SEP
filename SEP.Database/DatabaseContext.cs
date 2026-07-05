using Microsoft.EntityFrameworkCore;
using SEP.Database.Models;

namespace SEP.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Package> Packages => Set<Package>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SEP.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Package>().HasKey(x => x.Name);

        base.OnModelCreating(modelBuilder);
    }
}
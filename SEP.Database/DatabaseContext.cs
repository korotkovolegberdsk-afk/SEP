using Microsoft.EntityFrameworkCore;
using SEP.Database.Models;

namespace SEP.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Package> Packages => Set<Package>();

    public DatabaseContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SEP.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(x => x.PackageType)
                  .HasMaxLength(50);

            entity.Property(x => x.Description)
                  .HasMaxLength(500);
        });

        base.OnModelCreating(modelBuilder);
    }
}
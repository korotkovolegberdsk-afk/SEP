using Microsoft.EntityFrameworkCore;
using SEP.Database.Models;
using System;
using System.IO;

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
        string dataFolder = Path.Combine(
            AppContext.BaseDirectory,
            "data");

        // Создаем папку, если ее нет
        Directory.CreateDirectory(dataFolder);

        string dbPath = Path.Combine(
            dataFolder,
            "MasterLibrary.db");

        optionsBuilder.UseSqlite($"Data Source={dbPath}");
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
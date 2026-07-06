using System.Collections.Generic;
using System.Linq;
using SEP.Database.Models;

namespace SEP.Database;

public class DatabaseManager
{
    public DatabaseManager()
    {
        using var db = new DatabaseContext();

        if (!db.Packages.Any())
        {
            db.Packages.AddRange(
                new Package
                {
                    Name = "0201",
                    PackageType = "CHIP",
                    Description = "Chip Resistor / Capacitor",
                    Length = 0.60,
                    Width = 0.30,
                    Height = 0.25,
                    Pitch = 0.30,
                    Pins = 2
                },
                new Package
                {
                    Name = "0402",
                    PackageType = "CHIP",
                    Description = "Chip Resistor / Capacitor",
                    Length = 1.00,
                    Width = 0.50,
                    Height = 0.35,
                    Pitch = 0.50,
                    Pins = 2
                },
                new Package
                {
                    Name = "0603",
                    PackageType = "CHIP",
                    Description = "Chip Resistor / Capacitor",
                    Length = 1.60,
                    Width = 0.80,
                    Height = 0.45,
                    Pitch = 0.80,
                    Pins = 2
                },
                new Package
                {
                    Name = "0805",
                    PackageType = "CHIP",
                    Description = "Chip Resistor / Capacitor",
                    Length = 2.00,
                    Width = 1.25,
                    Height = 0.50,
                    Pitch = 1.25,
                    Pins = 2
                });

            db.SaveChanges();
        }
    }

    public List<Package> GetPackages()
    {
        using var db = new DatabaseContext();

        return db.Packages
                 .OrderBy(p => p.Name)
                 .ToList();
    }

    public void AddPackage(Package package)
    {
        using var db = new DatabaseContext();

        db.Packages.Add(package);
        db.SaveChanges();
    }

    public void RemovePackage(Package package)
    {
        using var db = new DatabaseContext();

        db.Packages.Remove(package);
        db.SaveChanges();
    }

    public void UpdatePackage(Package package)
    {
        using var db = new DatabaseContext();

        db.Packages.Update(package);
        db.SaveChanges();
    }
}
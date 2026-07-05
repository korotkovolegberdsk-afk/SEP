using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SEP.Database.Models;

namespace SEP.Database;

public class DatabaseManager
{
    private readonly List<Package> _packages;

    public DatabaseManager()
    {
        _packages = new List<Package>
        {
            new Package
            {
                Id = 1,
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
                Id = 2,
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
                Id = 3,
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
                Id = 4,
                Name = "0805",
                PackageType = "CHIP",
                Description = "Chip Resistor / Capacitor",
                Length = 2.00,
                Width = 1.25,
                Height = 0.50,
                Pitch = 1.25,
                Pins = 2
            }
        };
    }

    public bool DatabaseExists()
    {
        string databaseFile = Path.Combine(
            AppContext.BaseDirectory,
            "..",
            "..",
            "..",
            "..",
            "SEP.db");

        return File.Exists(Path.GetFullPath(databaseFile));
    }

    public List<Package> GetPackages()
    {
        return _packages;
    }

    public void AddPackage(Package package)
    {
        package.Id = _packages.Count == 0
            ? 1
            : _packages.Max(p => p.Id) + 1;

        _packages.Add(package);
    }

    public void RemovePackage(Package package)
    {
        _packages.Remove(package);
    }
}
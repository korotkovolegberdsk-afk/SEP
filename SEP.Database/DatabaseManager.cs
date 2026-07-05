using System;
using System.Collections.Generic;
using System.IO;
using SEP.Database.Models;

namespace SEP.Database;

public class DatabaseManager
{
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
        return new List<Package>
        {
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
            }
        };
    }
}
using SEP.Database;
using SEP.Library.Models;

namespace SEP.Library.Repositories;

public class PackageRepository
{
    private readonly DatabaseManager _database;

    public PackageRepository()
    {
        _database = new DatabaseManager();
    }

    public IReadOnlyList<Package> GetAll()
    {
        return _database
            .GetPackages()
            .Select(ConvertToLibraryPackage)
            .ToList();
    }

    public Package? GetById(int id)
    {
        return GetAll()
            .FirstOrDefault(p => p.Id == id);
    }

    public Package? GetByName(string name)
    {
        return GetAll()
            .FirstOrDefault(p =>
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void Add(Package package)
    {
        if (GetByName(package.Name) != null)
            return;

        _database.AddPackage(ConvertToDatabasePackage(package));
    }

    public void Update(Package package)
    {
        _database.UpdatePackage(ConvertToDatabasePackage(package));
    }

    public void Remove(Package package)
    {
        _database.RemovePackage(ConvertToDatabasePackage(package));
    }

    public void Clear()
    {
        foreach (var package in GetAll())
        {
            Remove(package);
        }
    }

    private static Package ConvertToLibraryPackage(
        SEP.Database.Models.Package package)
    {
        return new Package
        {
            Id = package.Id,
            Name = package.Name,

            Type = Enum.TryParse<PackageType>(
                package.PackageType,
                true,
                out var type)
                ? type
                : PackageType.Unknown,

            Length = package.Length,
            Width = package.Width,
            Height = package.Height,
            Pitch = package.Pitch,
            Pins = package.Pins,
            Description = package.Description
        };
    }

    private static SEP.Database.Models.Package ConvertToDatabasePackage(
        Package package)
    {
        return new SEP.Database.Models.Package
        {
            Id = package.Id,
            Name = package.Name,

            PackageType = package.Type.ToString(),

            Description = package.Description,
            Length = package.Length,
            Width = package.Width,
            Height = package.Height,
            Pitch = package.Pitch,
            Pins = package.Pins
        };
    }
}
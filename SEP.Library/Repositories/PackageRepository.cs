using SEP.Library.Models;

namespace SEP.Library.Repositories;

public class PackageRepository
{
    private readonly List<Package> _packages = new();

    public IReadOnlyList<Package> GetAll()
    {
        return _packages;
    }

    public Package? GetById(int id)
    {
        return _packages.FirstOrDefault(p => p.Id == id);
    }

    public Package? GetByName(string name)
    {
        return _packages.FirstOrDefault(p =>
            p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void Add(Package package)
    {
        if (GetByName(package.Name) != null)
            return;

        package.Id = _packages.Count + 1;

        _packages.Add(package);
    }

    public void Remove(Package package)
    {
        _packages.Remove(package);
    }
}
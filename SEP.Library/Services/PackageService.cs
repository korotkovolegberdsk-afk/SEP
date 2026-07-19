using SEP.Library.Models;
using SEP.Library.Repositories;

namespace SEP.Library.Services;

public class PackageService
{
    private readonly PackageRepository _repository = new();

    public IReadOnlyList<Package> GetPackages()
    {
        return _repository.GetAll();
    }

    public Package? GetPackage(string name)
    {
        return _repository.GetByName(name);
    }

    public void AddPackage(Package package)
    {
        _repository.Add(package);
    }

    public void RemovePackage(Package package)
    {
        _repository.Remove(package);
    }
}
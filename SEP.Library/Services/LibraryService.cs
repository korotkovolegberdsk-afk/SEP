using SEP.Library.Models;
using SEP.Library.Repositories;

namespace SEP.Library.Services;

/// <summary>
/// Центральный сервис SMT Library.
/// </summary>
public class LibraryService
{
    private readonly ComponentRepository _componentRepository = new();

    private readonly List<Package> _packages = new();

    #region Components

    public IReadOnlyList<Component> GetComponents()
    {
        return _componentRepository.GetAll();
    }

    public void AddComponent(Component component)
    {
        _componentRepository.Add(component);
    }

    public void RemoveComponent(Component component)
    {
        _componentRepository.Remove(component);
    }

    #endregion

    #region Packages

    public IReadOnlyList<Package> GetPackages()
    {
        return _packages;
    }

    #endregion
}
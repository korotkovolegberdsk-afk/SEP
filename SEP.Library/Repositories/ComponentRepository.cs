using SEP.Library.Models;

namespace SEP.Library.Repositories;

/// <summary>
/// Репозиторий компонентов SMT.
/// Пока работает с памятью.
/// Позже будет работать с SQLite.
/// </summary>
public class ComponentRepository
{
    private readonly List<Component> _components = new();

    /// <summary>
    /// Получить все компоненты.
    /// </summary>
    public IReadOnlyList<Component> GetAll()
    {
        return _components;
    }

    /// <summary>
    /// Добавить компонент.
    /// </summary>
    public void Add(Component component)
    {
        _components.Add(component);
    }

    /// <summary>
    /// Удалить компонент.
    /// </summary>
    public void Remove(Component component)
    {
        _components.Remove(component);
    }

    /// <summary>
    /// Очистить список.
    /// </summary>
    public void Clear()
    {
        _components.Clear();
    }
}
namespace SEP.Library.Models;

/// <summary>
/// Электронный компонент.
/// Главная сущность SMT Library.
/// </summary>
public class Component
{
    public int Id { get; set; }

    /// <summary>
    /// Наименование компонента.
    /// Например: STM32F407VGT6
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Каталожный номер производителя.
    /// </summary>
    public string PartNumber { get; set; } = "";

    /// <summary>
    /// Производитель.
    /// </summary>
    public Manufacturer? Manufacturer { get; set; }

    /// <summary>
    /// Корпус.
    /// </summary>
    public Package? Package { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; } = "";
}
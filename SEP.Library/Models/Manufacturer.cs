namespace SEP.Library.Models;

/// <summary>
/// Производитель электронных компонентов.
/// </summary>
public class Manufacturer
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование производителя.
    /// Например:
    /// STMicroelectronics
    /// Texas Instruments
    /// Microchip
    /// Murata
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Страна.
    /// </summary>
    public string Country { get; set; } = "";

    /// <summary>
    /// Сайт производителя.
    /// </summary>
    public string Website { get; set; } = "";

    /// <summary>
    /// Комментарий.
    /// </summary>
    public string Notes { get; set; } = "";
}
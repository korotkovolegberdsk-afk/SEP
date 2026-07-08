namespace SEP.Library.Models;

/// <summary>
/// Корпус электронного компонента.
/// </summary>
public class Package
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование корпуса.
    /// Например: 0603, SOIC-8, LQFP64.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Тип корпуса.
    /// Например: CHIP, SOIC, QFP, BGA.
    /// </summary>
    public string Type { get; set; } = "";

    /// <summary>
    /// Длина корпуса, мм.
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Ширина корпуса, мм.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Высота корпуса, мм.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Шаг выводов, мм.
    /// </summary>
    public double Pitch { get; set; }

    /// <summary>
    /// Количество выводов.
    /// </summary>
    public int Pins { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; } = "";
}
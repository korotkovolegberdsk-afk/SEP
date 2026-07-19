namespace SEP.Library.Models;

public class Component
{
    // Основное имя
    public string Name { get; set; } = "";


    // Производитель
    public string Manufacturer { get; set; } = "";


    // Yamaha / YGX данные
    public string PartNumber { get; set; } = "";

    public int DatabaseNo { get; set; }


    // Корпус
    public string PackageName { get; set; } = "";


    // Геометрия корпуса
    public double BodyX { get; set; }

    public double BodyY { get; set; }

    public double BodyZ { get; set; }


    // Источник данных
    public string Source { get; set; } = "";


    // Дополнительно
    public string Description { get; set; } = "";
}
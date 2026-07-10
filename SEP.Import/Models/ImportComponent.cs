namespace SEP.Import.Models;

public class ImportComponent
{
    // Основные данные
    public string Reference { get; set; } = "";

    public string PartNumber { get; set; } = "";

    public string Package { get; set; } = "";


    // Yamaha YGX
    public int DatabaseNo { get; set; }

    public int ShapeType { get; set; }

    public int PackageType { get; set; }


    // Координаты установки
    public double X { get; set; }

    public double Y { get; set; }

    public double Rotation { get; set; }


    // Геометрия корпуса
    public double BodyX { get; set; }

    public double BodyY { get; set; }

    public double BodyZ { get; set; }


    // Library данные Yamaha
    public int LibraryUse { get; set; }

    public int LibraryFolder { get; set; }

    public string LibraryPath { get; set; } = "";
}
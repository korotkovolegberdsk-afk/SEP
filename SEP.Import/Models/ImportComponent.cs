namespace SEP.Import.Models;

public class ImportComponent
{
    public string Reference { get; set; } = "";

    public string PartNumber { get; set; } = "";

    public string Package { get; set; } = "";

    public double X { get; set; }

    public double Y { get; set; }

    public double Rotation { get; set; }
}
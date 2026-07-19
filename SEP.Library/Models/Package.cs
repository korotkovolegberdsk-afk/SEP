namespace SEP.Library.Models;

public class Package
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public PackageType Type { get; set; } = PackageType.Unknown;

    public string IPCName { get; set; } = "";

    public string JEDECName { get; set; } = "";

    public string Description { get; set; } = "";

    // Geometry
    public double Length { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Pitch { get; set; }

    public int Pins { get; set; }

    // Stencil
    public double StencilThickness { get; set; }

    public double ApertureReduction { get; set; }

    // Yamaha
    public int YamahaDatabaseNo { get; set; }

    // AOI
    public string AOIAlgorithm { get; set; } = "";

    // Notes
    public string Notes { get; set; } = "";
}
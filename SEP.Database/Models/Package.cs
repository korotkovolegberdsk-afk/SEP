namespace SEP.Database.Models;

public class Package
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string PackageType { get; set; } = "";

    public string Description { get; set; } = "";

    public double Length { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Pitch { get; set; }

    public int Pins { get; set; }


    // SMT Engineering fields

    public double StencilThickness { get; set; }

    public double ApertureReduction { get; set; }

    public string AOIAlgorithm { get; set; } = "";

    public string Notes { get; set; } = "";


    public override string ToString()
    {
        return Name;
    }
}
namespace SEP.Database.Models;

public class Package
{
    public string Name { get; set; } = "";

    public string PackageType { get; set; } = "";

    public string Description { get; set; } = "";

    public double Length { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Pitch { get; set; }

    public int Pins { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
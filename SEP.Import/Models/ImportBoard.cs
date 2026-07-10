namespace SEP.Import.Models;

public class ImportBoard
{
    public string Name { get; set; } = "";

    public string FileName { get; set; } = "";

    public List<ImportComponent> Components { get; set; } = new();
}
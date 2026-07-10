namespace SEP.Import.Models;

public class ImportResult
{
    public string FileName { get; set; } = "";

    public int ComponentsCount { get; set; }

    public List<ImportComponent> Components { get; set; } = new();
}
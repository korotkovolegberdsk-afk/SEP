namespace SEP.Import.Models;

public class ImportResult
{
    public string FileName { get; set; } = "";

    public ImportBoard Board { get; set; } = new();

    public List<ImportComponent> Components { get; set; } = new();

    public int ComponentsCount => Components.Count;
}
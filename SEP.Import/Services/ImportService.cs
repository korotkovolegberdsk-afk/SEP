using SEP.Import.Interfaces;
using SEP.Import.Models;
using SEP.Library.Models;
using SEP.Library.Services;
using System.ComponentModel;

namespace SEP.Import.Services;

public class ImportService
{
    private readonly Dictionary<string, IImportParser> _parsers = new();


    private readonly LibraryService _library;


    public ImportService()
    {
        _library = new LibraryService();
    }


    public void Register(
        string extension,
        IImportParser parser)
    {
        _parsers[extension.ToLower()] = parser;
    }


    public ImportResult Import(string fileName)
    {
        string extension =
            Path.GetExtension(fileName).ToLower();


        if (!_parsers.TryGetValue(
                extension,
                out IImportParser? parser))
        {
            throw new NotSupportedException(
                $"Формат {extension} не поддерживается.");
        }


        ImportResult result =
            parser.Parse(fileName);


        SaveToLibrary(result);


        return result;
    }



    private void SaveToLibrary(
        ImportResult result)
    {
        foreach (ImportComponent item in result.Components)
        {
            Component component = new()
            {
                Name = item.Reference,

                PartNumber = item.PartNumber,

                DatabaseNo = item.DatabaseNo,

                PackageName =
                    item.Package,

                BodyX = item.BodyX,

                BodyY = item.BodyY,

                BodyZ = item.BodyZ,

                Source = "Yamaha YGX"
            };


            _library.AddComponent(component);
        }
    }
}
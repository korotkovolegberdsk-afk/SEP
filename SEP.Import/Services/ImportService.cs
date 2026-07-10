using SEP.Import.Interfaces;
using SEP.Import.Models;

namespace SEP.Import.Services;

public class ImportService
{
    private readonly Dictionary<string, IImportParser> _parsers = new();

    public void Register(string extension, IImportParser parser)
    {
        _parsers[extension.ToLower()] = parser;
    }

    public ImportResult Import(string fileName)
    {
        string extension = Path.GetExtension(fileName).ToLower();

        if (!_parsers.TryGetValue(extension, out IImportParser? parser))
            throw new NotSupportedException($"Формат {extension} не поддерживается.");

        return parser.Parse(fileName);
    }
}
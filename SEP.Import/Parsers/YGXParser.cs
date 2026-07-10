using SEP.Import.Interfaces;
using SEP.Import.Models;

namespace SEP.Import.Parsers;

public class YGXParser : IImportParser
{
    public ImportResult Parse(string fileName)
    {
        return new ImportResult
        {
            FileName = fileName
        };
    }
}
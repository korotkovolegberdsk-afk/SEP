using SEP.Import.Models;
using SEP.Import.Parsers;

namespace SEP.Import.Services;

public class YGXImportTest
{
    public ImportResult Load(string fileName)
    {
        YGXParser parser = new();

        return parser.Parse(fileName);
    }
}
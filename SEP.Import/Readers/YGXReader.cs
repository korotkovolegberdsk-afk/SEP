using System.Xml.Linq;

namespace SEP.Import.Readers;

public class YGXReader
{
    public XDocument Load(string fileName)
    {
        if (!File.Exists(fileName))
            throw new FileNotFoundException(
                "Файл YGX не найден",
                fileName);

        return XDocument.Load(fileName);
    }
}
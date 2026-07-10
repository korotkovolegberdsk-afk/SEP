using SEP.Import.Models;

namespace SEP.Import.Interfaces;

public interface IImportParser
{
    ImportResult Parse(string fileName);
}
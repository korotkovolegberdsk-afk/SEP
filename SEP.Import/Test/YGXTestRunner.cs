using SEP.Import.Parsers;

namespace SEP.Import.Test;

public class YGXTestRunner
{
    public void Run(string fileName)
    {
        YGXParser parser = new();

        var result = parser.Parse(fileName);

        Console.WriteLine(
            $"Файл: {result.FileName}");

        Console.WriteLine(
            $"Компонентов: {result.ComponentsCount}");

        foreach (var component in result.Components)
        {
            Console.WriteLine(
                $"{component.Reference}  {component.PartNumber}  {component.Package}");
        }
    }
}
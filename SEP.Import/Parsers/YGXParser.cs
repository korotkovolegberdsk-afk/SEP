using System.Xml.Linq;
using SEP.Import.Interfaces;
using SEP.Import.Models;
using SEP.Import.Readers;
using SEP.Import.Services;

namespace SEP.Import.Parsers;

public class YGXParser : IImportParser
{
    private readonly YGXReader _reader = new();

    private readonly YGXPackageResolver _resolver = new();


    public ImportResult Parse(string fileName)
    {
        XDocument document = _reader.Load(fileName);

        ImportResult result = new()
        {
            FileName = fileName,

            Board = new ImportBoard
            {
                FileName = fileName,
                Name = Path.GetFileNameWithoutExtension(fileName)
            }
        };


        foreach (XElement part in document.Descendants("Part"))
        {
            XElement? p001 = part.Element("Part_001");
            XElement? p002 = part.Element("Part_002");
            XElement? p003 = part.Element("Part_003");
            XElement? p012 = part.Element("Part_012");


            ImportComponent component = new()
            {
                Reference =
                    GetString(p001, "PartsName"),

                PartNumber =
                    GetString(p001, "Comment"),


                DatabaseNo =
                    GetInt(p001, "DatabaseNo"),


                ShapeType =
                    GetInt(p002, "ShapeType"),


                PackageType =
                    GetInt(p002, "Package"),


                X =
                    GetDouble(p003, "XPos"),

                Y =
                    GetDouble(p003, "YPos"),


                BodyX =
                    GetDouble(p012, "BodyX"),

                BodyY =
                    GetDouble(p012, "BodyY"),

                BodyZ =
                    GetDouble(p012, "BodyZ")
            };


            // Заполнение размеров из стандартной библиотеки,
            // если Yamaha не дала размеры
            _resolver.Resolve(component);


            result.Components.Add(component);
        }


        result.Board.Components = result.Components;

        return result;
    }



    private string GetString(
        XElement? element,
        string name)
    {
        return element?
            .Attribute(name)?
            .Value ?? "";
    }



    private int GetInt(
        XElement? element,
        string name)
    {
        int.TryParse(
            GetString(element, name),
            out int value);

        return value;
    }



    private double GetDouble(
        XElement? element,
        string name)
    {
        double.TryParse(
            GetString(element, name),
            System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture,
            out double value);

        return value;
    }
}
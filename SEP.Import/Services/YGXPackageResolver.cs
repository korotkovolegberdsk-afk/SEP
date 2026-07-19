using SEP.Import.Models;

namespace SEP.Import.Services;

public class YGXPackageResolver
{
    public void Resolve(ImportComponent component)
    {
        // Если Yamaha уже дала размеры корпуса
        if (component.BodyX > 0 &&
            component.BodyY > 0)
        {
            return;
        }


        string name =
            component.PartNumber
            .ToUpper();


        // Чип-компоненты
        if (name.Contains("0402"))
        {
            SetSize(component,
                1.0,
                0.5,
                0.5);
        }
        else if (name.Contains("0603"))
        {
            SetSize(component,
                1.6,
                0.8,
                0.6);
        }
        else if (name.Contains("0805"))
        {
            SetSize(component,
                2.0,
                1.25,
                0.8);
        }
        else if (name.Contains("1206"))
        {
            SetSize(component,
                3.2,
                1.6,
                1.0);
        }


        // SOT23
        else if (name.Contains("SOT23"))
        {
            SetSize(component,
                3.0,
                1.7,
                1.2);
        }


        // SOP8
        else if (name.Contains("SOP8"))
        {
            SetSize(component,
                5.0,
                4.0,
                1.75);
        }
    }



    private void SetSize(
        ImportComponent component,
        double x,
        double y,
        double z)
    {
        component.BodyX = x;
        component.BodyY = y;
        component.BodyZ = z;
    }
}
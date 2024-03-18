using LLS.Domain.Dtos;

namespace LLS.Domain.ExternalServices;

public class SmsPlanetPropEnum
{
    public string Name { get; private set; }

    public static SmsPlanetPropEnum From = new SmsPlanetPropEnum("from");
    public static SmsPlanetPropEnum To = new SmsPlanetPropEnum("to");
    public static SmsPlanetPropEnum Message = new SmsPlanetPropEnum("msg");

    private SmsPlanetPropEnum(string name)
    {
        Name = name;
    }

    public static implicit operator string(SmsPlanetPropEnum rE) => rE.Name;
}
using Raylib_cs;

namespace Blockade;

public class Palette
{
    public string Name { get; }
    public Color MainColor { get; }

    public Palette(string name, Color mainColor)
    {
        Name = name;
        MainColor = mainColor;
    }

    public bool Equals(Palette? other)
        => other is not null && Name == other.Name;
}
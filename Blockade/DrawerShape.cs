using Blockade.Math;

namespace Blockade;

internal class DrawerShape
{
    private readonly Shape _shape;
    public List<Rectangle> Blocks { get; }

    public DrawerShape(Shape shape, List<Rectangle> blocks)
    {
        _shape = shape;
        Blocks = blocks;
    }
}

internal sealed class DrawerShape2
{
    Shape Shape { get; init; }

    public int Width => Shape.Size.X;
    public int Height => Shape.Size.Y;

    public DrawerShape2(Shape shape)
    {
        Shape = shape;
    }
}

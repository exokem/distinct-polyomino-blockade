using Blockade.Math;

namespace Blockade;

internal class DrawerShape
{
    Shape Shape { get; init; }

    public int Width => Shape.Size.X;
    public int Height => Shape.Size.Y;

    public int TX { get; set; }
    public int TY { get; set; }

    public int Tiles => Shape.Tiles;

    public DrawerShape(Shape shape, int tx, int ty)
    {
        Shape = shape;
    }

    public List<Vec2i> MapPositions()
        => Shape.MapPlacementAt(new(TX, TY));
}

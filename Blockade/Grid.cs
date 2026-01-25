using Blockade.Math;

namespace Blockade;

public class Grid(int width, int height)
{
    private readonly Palette[,] _grid = new Palette[width, height];

    public Palette this[Vec2i position]
    {
        get => _grid[position.X, position.Y];
        set => _grid[position.X, position.Y] = value;
    }
}
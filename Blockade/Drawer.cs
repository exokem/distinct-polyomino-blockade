using Blockade.Math;
using Raylib_cs;

namespace Blockade;

internal class Drawer
{
    readonly Player _player;
    readonly IReadOnlyList<Shape> _shapes;
    readonly List<DrawerShape> _drawerShapes;

    public static int MainPadding => 10;
    public static int InteriorPadding => 10;
    public static int FontSize => 20;
    public static int TileSize => 40;
    public static int TileGap => 2;

    int ScoreAreaHeight => FontSize + 2 * InteriorPadding;

    public (Vec2i gridSize, Rec2i gridArea) GetGridArea(ref Rec2i area)
    {
        var tilesWide = 3;

        while (((tilesWide + 1) * TileSize) + tilesWide * TileGap <= area.W)
        {
            tilesWide++;
        }

        var tilesHigh = 3;
        while (((tilesHigh + 1) * TileSize) + tilesHigh * TileGap <= area.H)
        {
            tilesHigh++;
        }

        var width = tilesWide * TileSize + (tilesWide - 1) * TileGap;
        var height = tilesHigh * TileSize + (tilesHigh - 1) * TileGap;

        return (new(tilesWide, tilesHigh), new()
        {
            X = area.X + (area.W - width) / 2,
            Y = area.Y + (area.H - height) / 2,
            W = width,
            H = height,
        });
    }

    public Rec2i GetContentArea(ref Rec2i area)
        => area.Shrink(MainPadding, MainPadding);

    public Rec2i GetScoreArea(ref Rec2i area) => new()
    {
        X = area.X,
        Y = area.Y,
        W = area.W,
        H = ScoreAreaHeight,
    };

    public Rec2i GetShapeArea(ref Rec2i area) => new()
    {
        X = area.X,
        Y = area.Y + ScoreAreaHeight + MainPadding,
        W = area.W,
        H = area.H - ScoreAreaHeight - MainPadding,
    };

    public Drawer(Player player, List<Shape> shapes)
    {
        _player = player;
        _shapes = shapes;

        _drawerShapes = shapes.Select(shape => new DrawerShape(shape, 0, 0)).ToList();
    }

    public string GetScoreString()
    {
        var totalTiles = _shapes.Sum(shape => shape.Tiles);
        var remainingTiles = _drawerShapes.Sum(shape => shape.Tiles);
        var score = totalTiles - remainingTiles;

        return $"{score}/{totalTiles} placed tiles ({score} points)";
    }

    public List<DrawerShape> GetDrawerShapes()
    {
        return _drawerShapes;
    }

    private Rec2i MapTileToRect(ref Rec2i gridArea, int tx, int ty) => new()
    {
        X = gridArea.X + tx * (TileSize + TileGap),
        Y = gridArea.Y + ty * (TileSize + TileGap),
        W = TileSize,
        H = TileSize,
    };

    public IEnumerable<Rec2i> GetTileAreas(Vec2i gridSize, Rec2i gridArea)
    {
        for (var x = 0; x < gridSize.X; x++)
        {
            for (var y = 0; y < gridSize.Y; y++)
            {
                yield return MapTileToRect(ref gridArea, x, y);
            }
        }
    }

    public IEnumerable<Rec2i> GetFilledTileAreas(Vec2i gridSize, Rec2i gridArea)
    {
        UpdateShapePositions(ref gridSize);

        foreach (var shape in _drawerShapes)
        {
            foreach (var pos in shape.MapPositions())
            {
                yield return MapTileToRect(ref gridArea, pos.X, pos.Y);
            }
        }
    }

    void UpdateShapePositions(ref Vec2i gridSize)
    {
        int tx = 0, ty = 0;

        int rowHeight = 0;

        foreach (var shape in _drawerShapes)
        {
            if (gridSize.X < tx + shape.Width)
            {
                tx = 0;
                ty += rowHeight + 1;
                rowHeight = 0;
            }

            shape.TX = tx;
            shape.TY = ty;

            tx += shape.Width + 1;
            rowHeight = System.Math.Max(rowHeight, shape.Height);
        }
    }
}

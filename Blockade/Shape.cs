using Blockade.Math;

namespace Blockade;

internal sealed partial class Shape
{
    static readonly Dictionary<string, Shape> _shapes = [];

    public static bool FromName(string name, out Shape? shape)
    {
        return _shapes.TryGetValue(name, out shape);
    }

    public static readonly Shape
        // Straight pieces
        One = new("one", [new (0, 0)]),
        Two = new("two", [
            new (0, 0),
            new (1, 0)
        ]),
        Three = new("three", [
            new (0, 0),
            new (1, 0),
            new (2, 0)
        ]),
        Four = new("four", [
            new (0, 0),
            new (1, 0),
            new (2, 0),
            new (3, 0)
        ]),
        Five = new("five", [
            new (0, 0),
            new (1, 0),
            new (2, 0),
            new (3, 0),
            new (4, 0)
        ]),

        Square = new("square", [
            new (0, 0),
            new (1, 0),
            new (0, 1),
            new (1, 1)
        ]),
        Lump = new("lump", [
            new (0, 0),
            new (1, 0),
            new (2, 0),
            new (0, 1),
            new (1, 1),
        ])
    ;
}

internal sealed partial class Shape
{
    private readonly List<Vec2i> _shape = new();
    public string Name { get; }
    public Vec2i Size { get; }

    Shape(string name, List<Vec2i> shape)
    {
        Name = name;

        _shape = shape;
        _shapes[name] = this;

        Size = new()
        {
            X = shape.Max(v => v.X) + 1,
            Y = shape.Max(v => v.Y) + 1,
        };
    }

    public List<Vec2i> MapPlacementAt(Vec2i position)
    {
        List<Vec2i> placedPositions = [];

        foreach (var relativePos in _shape)
        {
            placedPositions.Add(new Vec2i(
                position.X + relativePos.X,
                position.Y + relativePos.Y
            ));
        }

        return placedPositions;
    }
}
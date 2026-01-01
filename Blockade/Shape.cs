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
        One = new("one", [new Vector2Int(0, 0)]),
        Two = new("two", [
            new Vector2Int(0, 0),
            new Vector2Int(1, 0)
        ]),
        Three = new("three", [
            new Vector2Int(0, 0),
            new Vector2Int(1, 0),
            new Vector2Int(2, 0)
        ]),
        Four = new("four", [
            new Vector2Int(0, 0),
            new Vector2Int(1, 0),
            new Vector2Int(2, 0),
            new Vector2Int(3, 0)
        ]),
        Five = new("five", [
            new Vector2Int(0, 0),
            new Vector2Int(1, 0),
            new Vector2Int(2, 0),
            new Vector2Int(3, 0),
            new Vector2Int(4, 0)
        ]),

        Square = new("square", [
            new Vector2Int(0, 0),
            new Vector2Int(1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(1, 1)
        ]),
        Lump = new("lump", [
            new Vector2Int(0, 0),
            new Vector2Int(1, 0),
            new Vector2Int(2, 0),
            new Vector2Int(0, 1),
            new Vector2Int(1, 1),
        ])
    ;
}

internal sealed partial class Shape
{
    private readonly List<Vector2Int> _shape = new();

    public string Name { get; }

    Shape(string name, List<Vector2Int> shape)
    {
        Name = name;

        _shape = shape;
        _shapes[name] = this;
    }

    public IEnumerable<Vector2Int> MapPlacementAt(Vector2Int position)
    {
        List<Vector2Int> placedPositions = new();

        foreach (Vector2Int relativePos in _shape)
        {
            placedPositions.Add(new Vector2Int(
                position.X + relativePos.X,
                position.Y + relativePos.Y
            ));
        }

        return placedPositions;
    }
}
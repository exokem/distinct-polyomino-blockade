using Blockade.Math;

namespace Blockade;

internal sealed partial class Shape
{
    static readonly Dictionary<string, Shape> _shapes = [];

    public static IEnumerable<Shape> All => _shapes.Values;

    public static bool FromName(string name, out Shape? shape)
    {
        return _shapes.TryGetValue(name, out shape);
    }

    public static readonly Shape
        // Straight pieces
        One = new("one", ["1"]),
        Two = new("two", ["11"]),
        Three = new("three", ["111"]),
        Four = new("four", ["1111"]),
        Five = new("five", ["11111"]),

        Square = new("square", [
            "11",
            "11"
        ]),
        Lump = new("lump", [
            "111",
            "110"
        ]),

        Signpost = new("signpost", [
            "011",
            "110",
            "010"
        ]),

        Steps = new("steps", [
            "01",
            "11"
        ]),
        Staircase = new("staircase", [
            "001",
            "011",
            "110",
        ]),

        Cross = new("cross", [
            "010",
            "111",
            "010",
        ]),

        Hook = new("hook", [
            "111",
            "001",
        ]),
        LongHook = new("long-hook", [
            "1111",
            "0001",
        ]),

        Lightning = new("lightning", [
            "110",
            "011",
        ]),
        LongLightning = new("long-lightning", [
            "1100",
            "0111",
        ]),

        Pike = new("pike", [
            "1111",
            "0100"
        ]),

        Corner = new("corner", [
            "001",
            "001",
            "111",
        ]),

        Nail = new("nail", [
            "111",
            "010",
        ]),
        LongNail = new("long-nail", [
            "111",
            "010",
            "010",
        ]),

        Bucket = new("bucket", [
            "101",
            "111"
        ]),

        Zed = new("zed", [
            "110",
            "010",
            "011"
        ])
    ;
}

internal sealed partial class Shape
{
    private readonly List<Vec2i> _shape = new();
    public string Name { get; }
    public Vec2i Size { get; }

    public int Width => Size.X;
    public int Height => Size.Y;

    // Shape(string name, List<Vec2i> shape)
    // {
    //     Name = name;
    //
    //     _shape = shape;
    //     _shapes[name] = this;
    //
    //     Size = new()
    //     {
    //         X = shape.Max(v => v.X) + 1,
    //         Y = shape.Max(v => v.Y) + 1,
    //     };
    // }

    static List<Vec2i> ParseStringShape(string[] shape)
    {
        List<Vec2i> positions = [];

        for (var y = 0; y < shape.Length; y++)
        {
            var line = shape[y];

            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '1')
                {
                    positions.Add(new(x, y));
                }
            }
        }

        return positions;
    }

    Shape(string name, string[] shape)
    {
        Name = name;

        _shape = ParseStringShape(shape);
        _shapes[name] = this;

        Size = new()
        {
            X = shape[0].Length,
            Y = shape.Length,
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
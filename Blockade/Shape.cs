namespace Blockade;

internal sealed partial class Shape
{
    static Dictionary<string, Shape> _shapes = new();

    public static bool FromName(string name, out Shape shape)
        => _shapes.TryGetValue(name, out shape);

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
    readonly bool[][] _shape;

    public string Name { get; }

    Shape(string name, bool[][] shape)
    {
        Name = name;
        _shape = shape;

        _shapes[name] = this;
    }

    Shape(string name, string[] shape)
    {
        Name = name;
        _shape = new bool[shape.Length][];

        for (var row = 0; row < shape.Length; row++)
        {
            _shape[row] = new bool[shape[row].Length];

            for (var col = 0; col < shape[row].Length; col++)
            {
                _shape[row][col] = shape[row][col] == '1';
            }
        }

        _shapes[name] = this;
    }
}
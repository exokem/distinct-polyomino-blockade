using System.Drawing;

namespace Blockade;

internal sealed partial class Player
{
    public Color Color { get; }
    public string Name { get; }
    private readonly Dictionary<Shape, BlockStatus> _blocks = [];

    public BlockStatus this[Shape shape]
    {
        get => _blocks.TryGetValue(shape, out var status) ? status : BlockStatus.Unusable;
        set => _blocks[shape] = value;
    }

    public Player(Color color, string name, Shape[] shapes)
    {
        Color = color;
        Name = name;

        foreach (var shape in shapes)
        {
            _blocks[shape] = BlockStatus.Available;
        }
    }
}
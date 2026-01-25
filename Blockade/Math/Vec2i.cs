namespace Blockade.Math;

public struct Vec2i
{
    public int X { get; init; }
    public int Y { get; init; }

    public Vec2i(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Vec2i Zero() => new Vec2i(0, 0);

    public Vec2i Offset(int x = 0, int y = 0)
        => new(X + x, Y + y);
}
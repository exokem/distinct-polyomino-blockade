namespace Blockade.Math;

public struct Vec2i(int x, int y)
{
    public int X => x;
    public int Y => y;

    public static Vec2i Zero() => new Vec2i(0, 0);

    public Vec2i Offset(int x = 0, int y = 0)
        => new(X + x, Y + y);
}
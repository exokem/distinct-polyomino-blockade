namespace Blockade.Math;

public struct Rec2i
{
    public int X { get; init; }
    public int Y { get; init; }
    public int W { get; init; }
    public int H { get; init; }

    public int Right => X + W;
    public int Bottom => Y + H;

    public Rec2i(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        W = width;
        H = height;
    }

    public Rec2i Shrink(int dx, int dy)
        => new(X + dx, Y + dy, W - dx * 2, H - dy * 2);

    public Rec2i Grow(int dx, int dy)
        => new(X - dx, Y - dy, W + dx * 2, H + dy * 2);

    public Rec2i Offset(int dx, int dy)
        => new(X + dx, Y + dy, W, H);

    public Rec2i Resize(int? nw = null, int? nh = null)
        => new(X, Y, nw ?? W, nh ?? H);

    public Vec2i Position()
        => new(X, Y);

    public Vec2i Size()
        => new(W, H);
}
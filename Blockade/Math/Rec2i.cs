namespace Blockade.Math;

public struct Rec2i(int x, int y, int width, int height)
{
    public int X => x;
    public int Y => y;
    public int W => width;
    public int H => height;

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
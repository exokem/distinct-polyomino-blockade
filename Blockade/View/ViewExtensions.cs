using Blockade.Math;
using Raylib_cs;

namespace Blockade.View;

public static class ViewExtensions
{
    public static void RenderFilled(this Rec2i rect, Color color)
        => Raylib.DrawRectangle(rect.X, rect.Y, rect.W, rect.H, color);

    public static void RenderOutlined(this Rec2i rect, Color color)
        => Raylib.DrawRectangleLines(rect.X, rect.Y, rect.W, rect.H, color);

    public static void Render(this string s, int x, int y, int size, Color color)
        => Raylib.DrawText(s, x, y, size, color);

    public static void Render(this string s, Vec2i pos, int size, Color color)
        => Raylib.DrawText(s, pos.X, pos.Y, size, color);
}
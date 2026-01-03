using Raylib_cs;

namespace Blockade
{
    public class Text
    {
        public readonly string Content;
        public readonly int FontSize;
        public readonly int X;
        public readonly int Y;
        public readonly Color Color;

        public Text(string content, int fontSize, int x, int y, Color color)
        {
            Content = content;
            FontSize = fontSize;
            X = x;
            Y = y;
            Color = color;
        }
    }
}
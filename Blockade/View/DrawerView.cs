using Blockade.Math;
using Raylib_cs;

namespace Blockade.View;

internal class DrawerView : IView
{
    private static void DrawRectange(Rectangle rectangle)
    {
        Raylib.DrawRectangle(
            rectangle.X,
            rectangle.Y,
            rectangle.Width,
            rectangle.Height,
            rectangle.Color
        );
    }

    private static void DrawText(Text text)
    {
        Raylib.DrawText(text.Content, text.X, text.Y, text.FontSize, text.Color);
    }

    private readonly Drawer drawer;

    public DrawerView(Drawer drawer)
    {
        this.drawer = drawer;
    }

    public void Draw(ref Rec2i area)
    {
        // Outer rect
        area.RenderFilled(Color.White);

        var contentArea = drawer.GetContentArea(ref area);

        // Score
        var scoreArea = drawer.GetScoreArea(ref contentArea);
        scoreArea.RenderFilled(Color.LightGray);
        drawer.GetScoreString().Render(scoreArea.Position().Offset(drawer.InteriorPadding, drawer.InteriorPadding), drawer.FontSize, Color.Black);

        // Shapes
        var shapeArea = drawer.GetShapeArea(ref contentArea);
        shapeArea.RenderFilled(Color.LightGray);
        shapeArea = shapeArea.Shrink(drawer.TileGap, drawer.TileGap);


        var (gridDimensions, gridArea) = drawer.GetGridArea(ref shapeArea);

        int rx = gridArea.X, ry = gridArea.Y;

        for (var x = 0; x < gridDimensions.X; x++)
        {
            ry = gridArea.Y;
            for (var y = 0; y < gridDimensions.Y; y++)
            {
                Raylib.DrawRectangle(rx, ry, drawer.TileSize, drawer.TileSize, Color.White);
                ry += drawer.TileSize + drawer.TileGap;
            }

            rx += drawer.TileSize + drawer.TileGap;
        }
    }
}

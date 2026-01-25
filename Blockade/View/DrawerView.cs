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


        var (gridSize, gridArea) = drawer.GetGridArea(ref shapeArea);

        int rx = gridArea.X, ry = gridArea.Y;

        foreach (var tile in drawer.GetTileAreas(gridSize, gridArea))
        {
            tile.RenderFilled(Color.White);
        }

        foreach (var tile in drawer.GetFilledTileAreas(gridSize, gridArea))
        {
            tile.RenderFilled(Color.Red);
        }
    }
}

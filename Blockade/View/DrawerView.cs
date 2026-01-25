using Blockade.Math;
using Raylib_cs;

namespace Blockade.View;

internal class DrawerView : IView
{
    readonly Drawer _drawer;

    public DrawerView(Drawer drawer)
    {
        _drawer = drawer;
    }

    public void Draw(ref Rec2i area)
    {
        // Outer rect
        area.RenderFilled(Color.White);

        var contentArea = _drawer.GetContentArea(ref area);

        // Score
        var scoreArea = _drawer.GetScoreArea(ref contentArea);
        scoreArea.RenderFilled(Color.LightGray);
        _drawer.GetScoreString().Render(scoreArea.Position().Offset(Drawer.InteriorPadding, Drawer.InteriorPadding), Drawer.FontSize, Color.Black);

        // Shapes
        var shapeArea = _drawer.GetShapeArea(ref contentArea);
        shapeArea.RenderFilled(Color.LightGray);
        shapeArea = shapeArea.Shrink(Drawer.TileGap, Drawer.TileGap);


        var (gridSize, gridArea) = _drawer.GetGridArea(ref shapeArea);

        int rx = gridArea.X, ry = gridArea.Y;

        foreach (var tile in _drawer.GetTileAreas(gridSize, gridArea))
        {
            tile.RenderFilled(Color.White);
        }

        foreach (var tile in _drawer.GetFilledTileAreas(gridSize, gridArea))
        {
            tile.RenderFilled(Color.Red);
        }
    }
}

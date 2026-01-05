using Raylib_cs;

namespace Blockade
{
    internal class DrawerView
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

        public void Draw()
        {
            DrawerView.DrawRectange(drawer.GetDrawerDimensions());
            DrawerView.DrawRectange(drawer.GetScoreAreaDimensions());
            DrawerView.DrawRectange(drawer.GetBlocksAreaDimensions());
            DrawerView.DrawText(drawer.GetScoreText());

            List<DrawerShape> drawerShapes = drawer.GetDrawerShapes();
            foreach (DrawerShape drawerShape in drawerShapes)
            {
                foreach (Rectangle block in drawerShape.Blocks)
                {
                    DrawerView.DrawRectange(block);
                }
            }
        }
    }
}
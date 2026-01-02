using Raylib_cs;

namespace Blockade
{
    public class DrawerView
    {
        private static readonly int BORDER_WIDTH = 20;
        private static readonly int BORDER_HEIGHT = 20;
        private static readonly int DRAWER_WIDTH = 500;
        private static readonly double PARTITION_RATIO = 0.10;

        public DrawerView()
        {
            
        }

        public void Draw(int screenWidth, int screenHeight)
        {
            int drawerX = screenWidth - DRAWER_WIDTH;
            int drawerY = 0;

            Raylib.DrawRectangle(drawerX, drawerY, DRAWER_WIDTH, screenHeight, Color.White);
            Raylib.DrawRectangleLines(
                drawerX + BORDER_WIDTH,
                drawerY + BORDER_HEIGHT,
                DRAWER_WIDTH - 2 * BORDER_WIDTH, 
                screenHeight - 2 * BORDER_HEIGHT, 
                Color.Black
            );
            Raylib.DrawLine(
                drawerX + BORDER_WIDTH, 
                drawerY + BORDER_HEIGHT + (int)((screenHeight - 2 * BORDER_HEIGHT) * PARTITION_RATIO), 
                screenWidth - BORDER_WIDTH, 
                drawerY + BORDER_HEIGHT + (int)((screenHeight - 2 * BORDER_HEIGHT) * PARTITION_RATIO), 
                Color.Black
            );

            Raylib.DrawText("Score Data", drawerX + BORDER_WIDTH + 10, drawerY + BORDER_HEIGHT + 10, 20, Color.Black);
            Raylib.DrawText("Blocks", drawerX + BORDER_WIDTH + 10, drawerY + BORDER_HEIGHT + (int)((screenHeight - 2 * BORDER_HEIGHT) * PARTITION_RATIO) + 10, 20, Color.Black);
        
            int blockSize = 40;
            Raylib.DrawRectangle(
                drawerX + BORDER_WIDTH + 10, 
                drawerY + BORDER_HEIGHT + (int)((screenHeight - 2 * BORDER_HEIGHT) * PARTITION_RATIO) + 50, 
                blockSize, 
                blockSize, 
                Color.White
            );
            Raylib.DrawRectangleLines(
                drawerX + BORDER_WIDTH + 10, 
                drawerY + BORDER_HEIGHT + (int)((screenHeight - 2 * BORDER_HEIGHT) * PARTITION_RATIO) + 50, 
                blockSize, 
                blockSize, 
                Color.Black
            );
            
        }
    }
}
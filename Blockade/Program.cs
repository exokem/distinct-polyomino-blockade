using Raylib_cs;

namespace Blockade
{
    public class Program
    {
        static void Main(string[] args)
        {
            Raylib.SetTargetFPS(60);
            Raylib.SetConfigFlags(ConfigFlags.FullscreenMode);
            Raylib.InitWindow(0, 0, "Distinct Polyomino Blockade");
            DrawerView drawerView = new();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                // Draw a box that's fixed to the right hand side of the screen
                drawerView.Draw(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()); 

                Raylib.DrawText("Hello, Blockade!", 10, 10, 20, Color.White);

                Raylib.EndDrawing();
            }
            
            Raylib.CloseWindow();
        }
    }
}
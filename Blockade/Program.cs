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
            Shape[] shapes = [Shape.One, Shape.Three, Shape.Two];
            Player a = new Player(new Palette("A", Color.Black), "A", shapes);
            Drawer drawer = new Drawer(a, shapes.ToList(), Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

            DrawerView drawerView = new(drawer);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                // Draw a box that's fixed to the right hand side of the screen
                drawerView.Draw(); 

                Raylib.DrawText("Hello, Blockade!", 10, 10, 20, Color.White);

                Raylib.EndDrawing();
            }
            
            Raylib.CloseWindow();
        }
    }
}
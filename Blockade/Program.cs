using Blockade.Math;
using Blockade.View;
using Raylib_cs;

namespace Blockade;

public class Program
{
    static void Main(string[] args)
    {
        var width = 1920;
        var height = 1080;

        Raylib.SetTargetFPS(60);
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        Raylib.InitWindow(width, height, "Distinct Polyomino Blockade");
        Shape[] shapes = Shape.All.ToArray();
        Player a = new Player(new Palette("A", Color.Black), "A", shapes);
        Drawer drawer = new Drawer(a, shapes.ToList(), Raylib.GetScreenWidth(), Raylib.GetScreenHeight());

        DrawerView drawerView = new(drawer);

        while (!Raylib.WindowShouldClose())
        {
            width = Raylib.GetScreenWidth();
            height = Raylib.GetScreenHeight();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // Draw a box that's fixed to the right hand side of the screen

            var drawerWidth = width / 3;
            Rec2i drawerArea = new(width - drawerWidth, 0, drawerWidth, height);

            drawerView.Draw(ref drawerArea);

            Raylib.DrawText("Hello, Blockade!", 10, 10, 20, Color.White);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}

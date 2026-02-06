
using Extiles_raylib;
using Raylib_cs;
using System.Diagnostics;
using System.Numerics;
public class Program
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 450;

    private static IRaylibScene currentScene = new NinePatch();
    private static List<int> keysThisFrame = new List<int>();
    // STAThread is required if you deploy using NativeAOT on Windows - See https://github.com/raylib-cs/raylib-cs/issues/301
    [System.STAThread]
    public static void Main()
    {
        var sw = new Stopwatch();
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "raylib [core] example - delta time");
        currentScene.Init();

        while (!Raylib.WindowShouldClose())
        {
            //exhaust all keys into a list
            while (true)
            {
                var keyPressed = Raylib.GetKeyPressed();
                if (keyPressed != 0)
                {
                    keysThisFrame.Add(keyPressed);
                }
                else
                {
                    break;
                }
            }
            if (keysThisFrame.Contains((int)KeyboardKey.F1))
            {
                Console.WriteLine("Switching to Nine FPS Test Scene");
                currentScene = new FPSTest();
                currentScene.Init();
            }
            if (keysThisFrame.Contains((int)KeyboardKey.F2))
            {
                Console.WriteLine("Switching to Nine Patch Scene");
                currentScene = new NinePatch();
                currentScene.Init();
            }



            currentScene.Input();
            currentScene.Update();

            Raylib.BeginDrawing();
            currentScene.Draw();
            Raylib.EndDrawing();

            //clear the keys
            keysThisFrame.Clear();
        }
        Raylib.CloseWindow();
    }
}
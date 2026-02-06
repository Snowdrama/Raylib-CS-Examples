using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RaylibCSExamples;

internal class FPSTest : IRaylibScene
{
    private string fpsText = "";
    private const float speed = 10.0f;
    private const float circleRadius = 32.0f;

    private int currentFps = 60;
    private int currentTargetFps = 60;

    private Vector2 deltaCircle;
    private Vector2 frameCircle;
    // Store the position for the both of the circles
    public void Init()
    {

        deltaCircle = new Vector2(0, (float)Program.SCREEN_HEIGHT / 3.0f);
        frameCircle = new Vector2(0, (float)Program.SCREEN_HEIGHT * (2.0f / 3.0f));
        Raylib.SetTargetFPS(currentFps);
    }
    public void Input()
    {
        var mouseWheel = Raylib.GetMouseWheelMove();
        if (mouseWheel != 0)
        {
            currentFps += (int)mouseWheel;
            if (currentFps < 0) currentFps = 0;
            Raylib.SetTargetFPS(currentFps);
        }
        if (currentFps != currentTargetFps)
        {
            currentTargetFps = currentFps;
            Raylib.SetTargetFPS(currentFps);
        }
    }
    public void Update()
    {
        fpsText = "";
        if (currentFps <= 0)
        {
            fpsText = $"FPS: unlimited {Raylib.GetFPS()}";
        }
        else
        {
            fpsText = $"FPS: {Raylib.GetFPS()} (target: {currentFps})";
        }
        deltaCircle.X += Raylib.GetFrameTime() * 6.0f * speed;
        frameCircle.X += 0.1f * speed;
    }

    public void Draw()
    {
        Raylib.ClearBackground(Color.RayWhite);
        // Draw both circles to the screen
        Raylib.DrawCircleV(deltaCircle, circleRadius, Color.Red);
        Raylib.DrawCircleV(frameCircle, circleRadius, Color.Blue);

        // Draw the help text
        // Determine what help text to show depending on the current FPS target
        Raylib.DrawText(fpsText, 10, 10, 20, Color.DarkGray);
        Raylib.DrawText($"Frame time: {Raylib.GetFrameTime()} ms", 10, 30, 20, Color.DarkGray);
        Raylib.DrawText("Use the scroll wheel to change the fps limit, r to reset", 10, 50, 20, Color.DarkGray);

        // Draw the text above the circles
        Raylib.DrawText("FUNC: x += GetFrameTime()*speed", 10, 90, 20, Color.Red);
        Raylib.DrawText("FUNC: x += speed", 10, 240, 20, Color.Blue);
    }
}

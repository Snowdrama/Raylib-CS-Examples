using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Extiles_raylib;

internal class NinePatch : IRaylibScene
{
    private NPatchInfo patchInfo = new NPatchInfo();
    private Rectangle dstRec1;
    private Texture2D texture;
    private Vector2 mousePosition;
    public void Init()
    {
        patchInfo.Top = 16;
        patchInfo.Bottom = 16;
        patchInfo.Left = 16;
        patchInfo.Right = 16;
        patchInfo.Source = new Rectangle(0, 0, 48, 48);
        patchInfo.Layout = NPatchLayout.NinePatch;

        dstRec1 = new(0, 0, 32.0f, 32.0f);
        texture = Raylib.LoadTexture("Content/Window9Slice.png");
    }

    public void Input()
    {
        mousePosition = Raylib.GetMousePosition();
    }

    public void Update()
    {
        // Resize the n-patches based on mouse position
        dstRec1.Width = mousePosition.X - dstRec1.X;
        dstRec1.Height = mousePosition.Y - dstRec1.Y;

        // Set a minimum Width and/or Height
        if (dstRec1.Width < 1.0f) dstRec1.Width = 1.0f;
        if (dstRec1.Height < 1.0f) dstRec1.Height = 1.0f;
    }

    public void Draw()
    {
        Raylib.ClearBackground(Color.RayWhite);
        Raylib.DrawTextureNPatch(texture, patchInfo, dstRec1, new Vector2(0, 0), 0, Color.Lime);
    }
}

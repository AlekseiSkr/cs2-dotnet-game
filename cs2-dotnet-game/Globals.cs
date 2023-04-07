using cs2_dotnet_game._Models.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace cs2_dotnet_game;
public static class Globals
{
    //public static float Time { get; set; }
    public static float TotalSeconds { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Point WindowSize { get; set; }
    public static Point Bounds { get; set; }    
    public static Game Game { get; set; }
    public static SpriteFont DialogFont { get; set; }
    public static Vector2 CenterScreen { get; set; }

    public static DragAndDropPacket DragAndDropPacket;

    public static int ScreenWidth
    {
        get
        {
            return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        }
    }

    public static int ScreenHeight
    {
        get
        {
            return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }
    }
    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;

    }
    
    public static void ExitGame(object sender, EventArgs e)
    {
        Game.Exit();
    }
}
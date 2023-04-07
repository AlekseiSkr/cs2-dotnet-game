using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

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

    public static void Update(GameTime gt)
    {
        TotalSeconds = (float)gt.ElapsedGameTime.TotalSeconds;

    }
    
    public static void ExitGame(object sender, EventArgs e)
    {
        Game.Exit();
    }
}
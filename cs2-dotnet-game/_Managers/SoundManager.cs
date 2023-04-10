using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;

namespace cs2_dotnet_game;
public static class SoundManager
{   
    private static Song _music;
    public static MenuButton vol0 { get; private set; }
    public static MenuButton vol25 { get; private set; }
    public static MenuButton vol50 { get; private set; }
    public static MenuButton vol75 { get; private set; }
    public static MenuButton vol100 { get; private set; }

    public static void Init()
    {
        //_music = Globals.Content.Load<Song>("Sound/background");

        var x = Globals.Bounds.X / 2;
        var y = Globals.Bounds.Y / 2;

        MediaPlayer.IsRepeating = true;
        MediaPlayer.Volume = 0.0f;
        //MediaPlayer.Play(_music);
        vol0 = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x - 100, y))
        {
            Text = "0",
        };
        vol0.OnClick += Select0Volume;
        vol25 = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x + 50, y))
        {
            Text = "25",
        };
        vol25.OnClick += Select25Volume;
        vol50 = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x + 200, y))
        {
            Text = "50",
        };
        vol50.OnClick += Select50Volume;
        vol75 = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x + 350, y))
        {
            Text = "75",
        };
        vol75.OnClick += Select75Volume;
        vol100 = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x + 500, y))
        {
            Text = "100",
        };
        vol100.OnClick += Select100Volume;
    }

    public static void Select0Volume(Object sender, EventArgs e)
    {
        MediaPlayer.Volume = 0f;
        vol0.Disabled = true;
        vol25.Disabled = false;
        vol50.Disabled = false;
        vol75.Disabled = false;
        vol100.Disabled = false;
    }

    public static void Select25Volume(Object sender, EventArgs e)
    {
        MediaPlayer.Volume = 0.25f;
        vol0.Disabled = false;
        vol25.Disabled = true;
        vol50.Disabled = false;
        vol75.Disabled = false;
        vol100.Disabled = false;
    }

    public static void Select50Volume(Object sender, EventArgs e)
    {
        MediaPlayer.Volume = 0.50f;
        vol0.Disabled = false;
        vol25.Disabled = false;
        vol50.Disabled = true;
        vol75.Disabled = false;
        vol100.Disabled = false;
    }

    public static void Select75Volume(Object sender, EventArgs e)
    {
        MediaPlayer.Volume = 0.75f;
        vol0.Disabled = false;
        vol25.Disabled = false;
        vol50.Disabled = false;
        vol75.Disabled = true;
        vol100.Disabled = false;
    }

    public static void Select100Volume(Object sender, EventArgs e)
    {
        MediaPlayer.Volume = 1f;
        vol0.Disabled = false;
        vol25.Disabled = false;
        vol50.Disabled = false;
        vol75.Disabled = false;
        vol100.Disabled = true;
    }
}

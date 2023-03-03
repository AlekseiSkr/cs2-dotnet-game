using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using cs2_dotnet_game._Models;

namespace cs2_dotnet_game._Manager;
public static class SoundManager
{
    public static bool MusicOn { get; private set; }
    public static bool SoundsOn { get; private set; }
    
    private static Song _music;
    public static Button MusicButton { get; private set; }
    public static Button SoundButton { get; private set; }

    public static void Init()
    {
        _music = Globals.Content.Load<Song>("Sound/background");

        MusicOn = true;
        SoundsOn= true;

        MediaPlayer.IsRepeating= true;
        MediaPlayer.Volume= 0.4f;
        MediaPlayer.Play(_music);

        MusicButton = new(Globals.Content.Load<Texture2D>("Menu/music"), new(50, 50));
        MusicButton.OnClick += SwitchMusic;
        SoundButton = new(Globals.Content.Load<Texture2D>("Menu/sounds"), new(130, 50));
        SoundButton.OnClick += SwitchSounds;
    }

    public static void SwitchMusic(object sender, EventArgs e)
    {
        MusicOn = !MusicOn;
        MediaPlayer.Volume = MusicOn ? 0.2f : 0f;
        MusicButton.Disabled = !MusicOn;
    }

    public static void SwitchSounds(Object sender, EventArgs e)
    {
        SoundsOn= !SoundsOn;
        SoundButton.Disabled = !SoundsOn;
    }

}

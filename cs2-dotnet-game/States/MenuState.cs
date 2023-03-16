using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace cs2_dotnet_game;

public class MenuState : State
{
    private readonly List<Button> _buttons = new();

    public MenuState(GameManager gm) 
    {
        var r = new Random();
        var x = Globals.Bounds.X / 2;
        var y = Globals.Bounds.Y / 2;
        addButton(new(Globals.Content.Load<Texture2D>("Menu/easy"), new(x + 300, y))).OnClick += gm.start;
        addButton(new(Globals.Content.Load<Texture2D>("Menu/medium"), new(x + 100, y))).OnClick += gm.playerBaseState;
        addButton(SoundManager.SoundButton);
        addButton(SoundManager.MusicButton);
    }
    
    private Button addButton(Button button)
    {
        _buttons.Add(button);
        return button;
    }

    private static void playMusic(object sender, EventArgs e)
    {
        
    }
    public override void Draw(GameManager gm)
    {
        foreach (var button in _buttons)
        {
            button.Draw();
        }
    }

    public override void update(GameManager gm)
    {
        foreach (var button in _buttons)
        {
            button.Update();
        }
    }
}

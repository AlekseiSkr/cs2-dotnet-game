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
        Button newGame = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x, y - 250))
        {
            Text = "New Game", 
        };
        Button loadGame = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x, y - 200))
        {
            Text = "Load Game",
        };
        Button optionGame = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x, y - 150))
        {
            Text = "Option Game",
        };
        Button exitGame = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x, y - 100))
        {
            Text = "Exit Game",
        };
        newGame.OnClick+= gm.start;
        addButton(newGame);
        addButton(loadGame);
        addButton(optionGame);
        addButton(exitGame);
        addButton(SoundManager.SoundButton);
        addButton(SoundManager.MusicButton);
    }
    
    private Button addButton(Button button)
    {
        _buttons.Add(button);
        return button;
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

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
        MenuButton newGame = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x, y - 250))
        {
            Text = "New Game", 
        };
        MenuButton loadGame = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x, y - 200))
        {
            Text = "Load Game",
        };
        MenuButton optionGame = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x, y - 150))
        {
            Text = "Option Game",
        };
        MenuButton exitGame = new(Globals.Content.Load<Texture2D>("Menu/Button"), new(x, y - 100))
        {
            Text = "Exit Game",
        };
        newGame.OnClick += gm.Start;
        AddButton(newGame);
        AddButton(loadGame);
        AddButton(optionGame);
        AddButton(exitGame);
        AddButton(SoundManager.SoundButton);
        AddButton(SoundManager.MusicButton);
    }
    
    private Button AddButton(Button button)
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

    public override void Update(GameManager gm)
    {
        foreach (var button in _buttons)
        {
            button.Update();
        }
    }
}

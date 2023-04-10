using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace cs2_dotnet_game;

public class MenuState : State
{
    private readonly List<Button> _buttons = new();
    private readonly Texture2D backgroundTexture;

    public MenuState(GameManager gm) 
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("Menu/menu_background");
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
        newGame.OnClick += gm.DialogbBx;
        //IMPORTANT: IMPLEMENT SAVE WHEN THIS IS CALLED
        exitGame.OnClick += gm.Quit;
        AddButton(newGame);
        AddButton(loadGame);
        AddButton(optionGame);
        AddButton(exitGame);

        //tempo buttons
        Button buttonTrade = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 1000));
        buttonTrade.OnClick += gm.TraderState;
        //buttonTrade.OnClick += gm.LoseState;
        Button buttonPlayerBase = new(Globals.Content.Load<Texture2D>("backButton"), new(300, 1000));
        buttonPlayerBase.OnClick += gm.PlayerBaseState;
        Button buttonBoss = new(Globals.Content.Load<Texture2D>("backButton"), new(500, 1000));
        buttonBoss.OnClick += gm.BossMansionState;
        Button buttonEnemyBase = new(Globals.Content.Load<Texture2D>("backButton"), new(700, 1000));
        buttonEnemyBase.OnClick += gm.EnemyState;

        AddButton(buttonTrade);
        AddButton(buttonPlayerBase);
        AddButton(buttonBoss);
        AddButton(buttonEnemyBase);
    }
    
    private Button AddButton(Button button)
    {
        _buttons.Add(button);
        return button;
    }

    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
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

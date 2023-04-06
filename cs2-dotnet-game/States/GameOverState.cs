﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;
public class GameOverState : State
{
    private readonly Texture2D backgroundTexture;
    private GameManager _gm;
    public GameOverState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("death");
        _gm = gm;
    }

    public override void Draw(GameManager gm)
    {
        ReturnToMenu();
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), "as the sky turns to dark, you can't help but feel remorse. you have let your ancestors down ... you have failed yourself", new Vector2(500, 100), Color.Black);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), "yet, the world would live on to see another sunrise", new Vector2(500, 130), Color.Black);
    }

    public override void Update(GameManager gm)
    {

    }

    private async void ReturnToMenu()
    {
        await Task.Delay(10000);
        _gm.ChangeState(GameStates.Menu);
    }
}

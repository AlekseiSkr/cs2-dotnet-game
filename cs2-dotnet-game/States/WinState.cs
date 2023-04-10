using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;
public class WinState : State
{
    private readonly Texture2D backgroundTexture;
    private String text = "";
    private String text2 = "";
    private String text3 = "";
    private String text4 = "";
    private String text5 = "";
    public WinState()
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("win");
    }
    public override void Draw(GameManager gm)
    {
        EndCredits();
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), text, new Vector2(650, 950), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), text2, new Vector2(650, 980), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), text3, new Vector2(750, 980), Color.Red);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), text4, new Vector2(650, 1010), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), text5, new Vector2(900, 400), Color.White);
    }

    public override void Update(GameManager gm)
    {

    }

    private async void EndCredits()
    {
        await Task.Delay(4000);
        text = "you emerge victorious ... all these years ... the suffering is over";
        await Task.Delay(5000);
        text2 = "rest now, ";
        await Task.Delay(2500);
        text3 = "hero";
        await Task.Delay(3000);
        text4 = "for tomorrow ... we start anew";
        await Task.Delay(3000);
        text5 = "Thank you for playing!";
        await Task.Delay(2000);
        Globals.Game.Exit();
    }

}


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;

public class TraderState : State
{
    private Texture2D backgroundTexture;

    private Button buttonTrade;
    private Button buttonLeaveTrader;
    
    public TraderState(GameManager gm)
    {
        GenerateRectangleBackground();
        backgroundTexture = Globals.Content.Load<Texture2D>("Trader/traderGuns");

        buttonTrade = new(Globals.Content.Load<Texture2D>("Trader/tradeButton"), new(100, 500));

        buttonLeaveTrader = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 850));
        buttonLeaveTrader.OnClick += gm.MenuState;
    }
    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);
        buttonTrade.Draw();
        buttonLeaveTrader.Draw();
    }

    public override void Update(GameManager gm)
    {
        buttonTrade.Update();
        buttonLeaveTrader.Update();
    }
}
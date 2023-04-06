using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;

public class TradingState : State
{
    private Texture2D backgroundTexture;
    private Rectangle playerInventoryRectangle;
    private Rectangle traderInventoryRectangle;

    private readonly Button buttonLeaveTrading;
    public TradingState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("Misc/background2");
        buttonLeaveTrading = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 850));
        buttonLeaveTrading.OnClick += gm.TraderState;
    }
    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
        buttonLeaveTrading.Draw();
    }

    public override void Update(GameManager gm)
    {
        buttonLeaveTrading.Update();
    }
}
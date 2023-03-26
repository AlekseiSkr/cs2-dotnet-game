using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;

public class BossMansionState : State
{
    private Texture2D bossCastle;

    private readonly Button buttonLeaveGates;
    private readonly Button buttonEnterGate;

    //temp
    private int playerKeys = 1;
    public BossMansionState(GameManager gm)
    {
        bossCastle = Globals.Content.Load<Texture2D>("Boss/bossBase");

        buttonLeaveGates = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 850));
        buttonLeaveGates.OnClick += gm.MenuState;

        buttonEnterGate = new(Globals.Content.Load<Texture2D>("Boss/gates"), new(100, 500));
        //buttonEnterGate.OnClick += gm.BossState;
        buttonEnterGate.OnClick += gm.TraderState;
    }
    public override void Draw(GameManager gm)
    {
        //draw the background image in its original size
        Globals.SpriteBatch.Draw(bossCastle, new Rectangle(0, 0, 1920, 1080), Color.White);
        buttonLeaveGates.Draw();
        buttonEnterGate.Draw();

        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("ComicSans"), "You have " + playerKeys + " keys", new Vector2(100, 100), Color.White);

    }

    public override void Update(GameManager gm)
    {
        buttonLeaveGates.Update();
        if (playerKeys >= 3)
        {
            buttonEnterGate.Update();
        }
    }
}
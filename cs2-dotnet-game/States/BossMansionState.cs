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
    private int playerKeys = 3;
    public BossMansionState(GameManager gm)
    {
        bossCastle = Globals.Content.Load<Texture2D>("Boss/bossBase");

        buttonLeaveGates = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 1000));
        buttonLeaveGates.OnClick += gm.PlayerBaseState;

        buttonEnterGate = new(Globals.Content.Load<Texture2D>("Boss/gates"), new(1100, 720));
        //buttonEnterGate.OnClick += gm.BossState;
        buttonEnterGate.OnClick += gm.BossState;
    }
    public override void Draw(GameManager gm)
    {
        //draw the background image in its original size
        Globals.SpriteBatch.Draw(bossCastle, new Rectangle(0, 0, 1920, 1080), Color.White);
        buttonLeaveGates.Draw();
        buttonEnterGate.Draw();

        if (gm.player.keysObtained < 3)
        {
            Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), "You need at least 3 keys to unlock the gates!", new Vector2(100, 100), Color.Red);
            Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), "You currently have " + gm.player.keysObtained + " key(s)", new Vector2(100, 130), Color.White);

        }
        else if (gm.player.keysObtained >= 3)
        {
            Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), "You have enough keys to unlock the gates!", new Vector2(100, 100), Color.LightGreen);
        }



    }

    public override void Update(GameManager gm)
    {
        buttonLeaveGates.Update();
        if (gm.player.keysObtained >= 3)
        {
            buttonEnterGate.Update();
        }
    }
}
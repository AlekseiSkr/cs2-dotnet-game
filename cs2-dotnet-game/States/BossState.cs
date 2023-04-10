using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;

public class BossState : State
{
    private readonly Button buttonLeave;
    private readonly Button buttonAttack;
    private readonly Button buttonDefend;
    private readonly Button buttonSkipRound;
    private readonly Button buttonInventory;

    private Texture2D backgroundTexture;
    private Texture2D playerTexture;
    private Texture2D enemyTexture;

    //temp
    private readonly Button buttonLeaveBase;
    public BossState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("Boss/bossBack");

        //temp
        buttonLeaveBase = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 1000));
        buttonLeaveBase.OnClick += gm.MenuState;
    }
    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), "Having killed his hordes, the boss' power faded and he passed away. His castle is now yours for the taking", new Vector2(400, 200), Color.Black);
        buttonLeaveBase.Draw();
    }

    public async override void Update(GameManager gm)
    {
        buttonLeaveBase.Update();
        if (gm.player.keysObtained >= 3)
        {
            await Task.Delay(5000);
            gm.ChangeState(GameStates.Win);
        }
    }
}

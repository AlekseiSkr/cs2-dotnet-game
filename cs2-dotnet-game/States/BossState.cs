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
    private readonly Texture2D backgroundTexture;

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
        buttonLeaveBase.Draw();
    }

    public override void Update(GameManager gm)
    {
        buttonLeaveBase.Update();
    }
}

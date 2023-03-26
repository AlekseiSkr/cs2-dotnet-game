using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;

public class EnemyBaseState : State
{
    private readonly Button buttonLeave;
    public EnemyBaseState(GameManager gm)
    {
        buttonLeave = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 850));
        buttonLeave.OnClick += gm.MenuState;
    }
    public override void Draw(GameManager gm)
    {
        buttonLeave.Draw();
    }

    public override void Update(GameManager gm)
    {
        buttonLeave.Update();
    }
}

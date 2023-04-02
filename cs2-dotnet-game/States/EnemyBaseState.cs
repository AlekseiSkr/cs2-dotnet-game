using Microsoft.Xna.Framework;
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

    private int healthPoints = 100;
    private int battlePoints = 0;
    private int staminaPoints = 5;
    private int xp  = 0;

    private int enemyHP = 100;
    private int enemyBP = 50;
    private int enemySP = 5;

    private readonly Button buttonAttack;
    private readonly Button buttonDefend;
    private readonly Button buttonSkipRound;


    public EnemyBaseState(GameManager gm)
    {
        buttonLeave = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 850));
        buttonLeave.OnClick += gm.MenuState;
        //buttonAttack = 
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

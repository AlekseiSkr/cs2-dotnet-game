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
    private readonly Button buttonInventory;


    public EnemyBaseState(GameManager gm)
    {
        buttonLeave = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 1000));
        buttonLeave.OnClick += gm.MenuState;
        
        buttonAttack = new(Globals.Content.Load<Texture2D>("Enemy/Attack"), new(300, 850));
        buttonDefend = new(Globals.Content.Load<Texture2D>("Enemy/defend"), new(500, 850));
        buttonSkipRound = new(Globals.Content.Load<Texture2D>("Enemy/143-glossy-round-button-arrow-109083212"), new(700, 850));
        buttonInventory = new(Globals.Content.Load<Texture2D>("Enemy/items"), new(900, 850));
    }
    public override void Draw(GameManager gm)
    {
        buttonLeave.Draw();
        buttonAttack.Draw();
        buttonDefend.Draw();
        buttonSkipRound.Draw();
        buttonInventory.Draw();
    }

    public override void Update(GameManager gm)
    {
        buttonLeave.Update();
        buttonAttack.Update();
        buttonDefend.Update();
        buttonSkipRound.Update();
        buttonInventory.Update();
    }
}

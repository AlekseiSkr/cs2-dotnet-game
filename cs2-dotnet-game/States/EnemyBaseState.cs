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
    

    private int healthPoints = 100;
    private int battlePoints = 0;
    private int staminaPoints = 5;
    private int xp  = 500;

    private int enemyHP = 100;
    private int enemyBP = 50;
    private int enemySP = 5;

    private readonly Button buttonLeave;
    private readonly Button buttonAttack;
    private readonly Button buttonDefend;
    private readonly Button buttonSkipRound;
    private readonly Button buttonInventory;

    private Texture2D backgroundTexture;
    private Texture2D playerTexture;
    private Texture2D enemyTexture;

    private GameManager _gm;


    public EnemyBaseState(GameManager gm)
    {
        //backgroundTexture = Globals.Content.Load<Texture2D>(GetBackground());
        backgroundTexture = Globals.Content.Load<Texture2D>("Enemy/1");
        playerTexture = Globals.Content.Load<Texture2D>("Player/playerIdle");
        enemyTexture = Globals.Content.Load<Texture2D>("Enemy/enemy1");

        buttonLeave = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 1000));
        //buttonLeave.OnClick += gm.MenuState;
        buttonLeave.OnClick += Leave;
        
        buttonAttack = new(Globals.Content.Load<Texture2D>("Enemy/Attack"), new(100, 200));
        buttonDefend = new(Globals.Content.Load<Texture2D>("Enemy/defend"), new(100, 400));
        buttonInventory = new(Globals.Content.Load<Texture2D>("Enemy/items"), new(100, 600));
        buttonSkipRound = new(Globals.Content.Load<Texture2D>("Enemy/143-glossy-round-button-arrow-109083212"), new(100, 800));
        _gm = gm;

        buttonAttack.OnClick += Attack;
        buttonDefend.OnClick += Defend;
        buttonInventory.OnClick += Inventory;
        buttonSkipRound.OnClick += SkipRound;
        
    }
    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
        Globals.SpriteBatch.Draw(playerTexture, new Rectangle(200, 300, 500, 500), Color.White);
        Globals.SpriteBatch.Draw(enemyTexture, new Rectangle(1100, 300, 740, 500), Color.White);
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

    private String GetBackground()
    {
        //generate a random number between one and three, and return the corresponding background
        Random rnd = new Random();
        int number = rnd.Next(1, 4);
        String background = "Enemy/" + number.ToString();
        return background;
    }

    private void Attack(object sender, EventArgs e)
    {
        UpdateCombat(1);
    }
    private void AttackSpell(object sender, EventArgs e)
    {
        UpdateCombat(2);
    }

    private void Defend(object sender, EventArgs e)
    {
        //defend against the enemy
        UpdateCombat(3);
    }

    private void SkipRound(object sender, EventArgs e)
    {
        //skip the round
        UpdateCombat(4);
    }

    private void Inventory(object sender, EventArgs e)
    {
        //open the inventory
        UpdateCombat(7);
    }

    private async void Leave(object sender, EventArgs e)
    {
        //reduce player ex and leave the battle state
        xp -= 100;
        await Task.Delay(300);
        _gm.ChangeState(GameStates.Menu);

    }
    //fight state 0 = player idle, 1 = player attack, 2 = player attack spell, 3 = player defend 4 = player skip round, 5 = player inventory, 6 = enemy idle, 7 = enemy attack, 8 = enemy defeat.
    private async void UpdateCombat(int fightState)
    {
        await Task.Delay(300);
        
        switch (fightState)
        {
            case 0:
                playerTexture = Globals.Content.Load<Texture2D>("Player/playerIdle");
                break;
            case 1:
                //player attack
                playerTexture = Globals.Content.Load<Texture2D>("Player/playerShooting");
                enemyTexture = Globals.Content.Load<Texture2D>("Enemy/enemyDefend");
                break;
            case 2:
                //player attack spell
                playerTexture = Globals.Content.Load<Texture2D>("Player/playerSpell");
                break;
            case 3:
                //player defend
                playerTexture = Globals.Content.Load<Texture2D>("Player/playerDefend");
                break;
            case 4:
                //player skip round
                playerTexture = Globals.Content.Load<Texture2D>("Player/playerIdle");
                break;
            case 5:
                //player inventory
                break;
            case 6:
                //enemy idle
                enemyTexture = Globals.Content.Load<Texture2D>("Enemy/enemy1");
                break;
            case 7:
                //enemy attack
                enemyTexture = Globals.Content.Load<Texture2D>("Enemy/enemyFight");
                playerTexture = Globals.Content.Load<Texture2D>("Player/playerDefend");
                break;
            case 8:
                //enemy defeat
                enemyTexture = Globals.Content.Load<Texture2D>("Enemy/enemyDead");
                break;
            default:
                playerTexture = Globals.Content.Load<Texture2D>("Player/playerIdle");
                enemyTexture = Globals.Content.Load<Texture2D>("Enemy/enemy1");
                break;
        }
   
        //wait for 3 seconds
        await Task.Delay(3000);
        //reset the player texture
        playerTexture = Globals.Content.Load<Texture2D>("Player/playerIdle");
        enemyTexture = Globals.Content.Load<Texture2D>("Enemy/enemy1");
    }


}

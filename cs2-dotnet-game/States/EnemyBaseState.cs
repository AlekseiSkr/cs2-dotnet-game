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
    private int battlePoints = 100;
    private int staminaPoints = 5;
    private int xp = 500;
    private int attackBPCost = 40;
    private int defendBPCost = 20;
    private int attackEfficiency = 35;

    private bool defend = false;

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
    private String hp, bp, sp, enemyhp, errorBp, skip, nextTurn;


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

        hp = "HP: " + healthPoints;
        bp = "BP: " + battlePoints;
        sp = "SP: " + staminaPoints;
        enemyhp = "HP: " + enemyHP;
        errorBp = "";
        skip = "";
        nextTurn = "";
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

        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), hp, new Vector2(400, 900), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), bp, new Vector2(400, 950), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), sp, new Vector2(400, 1000), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), enemyhp, new Vector2(1500, 900), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), errorBp, new Vector2(400, 200), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), skip, new Vector2(400, 200), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), nextTurn, new Vector2(400, 200), Color.White);
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

    private async void EnemyAttack()
    {
        UpdateCombat(7);
        if (defend)
        {
            healthPoints -= (attackEfficiency / 2);
        }
        else
        {
            healthPoints -= 35;
        }
        if (healthPoints <= 0)
        {
            await Task.Delay(200);
            //lose state!
        }
    }

    private async void Attack(object sender, EventArgs e)
    {
        if (battlePoints >= attackBPCost)
        {
            //attack the enemy
            //80% chance of success
            Random rnd = new Random();
            int number = rnd.Next(1, 101);
            if (number < 80)
            {
                UpdateCombat(1);
                battlePoints -= attackBPCost;
                bp = "BP: " + battlePoints;
                ChangeMessages(5);

                if (battlePoints == 0)
                {
                    await Task.Delay(2000);
                    ChangeMessages(2);
                    await Task.Delay(2000);
                    battlePoints = 10 * staminaPoints;
                    bp = "BP: " + battlePoints;
                    await Task.Delay(200);
                    EnemyAttack();
                }
            }
            else
            {
                ChangeMessages(4);
            }
        }
        else
        {
            //not enough battle points
            ChangeMessages(0);
        }
    }
    private void AttackSpell(object sender, EventArgs e)
    {
        UpdateCombat(2);
    }

    private async void Defend(object sender, EventArgs e)
    {
        //defend against the enemy
        if (battlePoints >= defendBPCost)
        {
            UpdateCombat(3);
            defend = true;
            battlePoints = 0;
            bp = "BP: " + battlePoints;
            ChangeMessages(2);

            await Task.Delay(2000);
            //battlePoints = 10 * staminaPoints;
            battlePoints = 40;
            bp = "BP: " + battlePoints;
        }
        else
        {
            //not enough battle points
            ChangeMessages(0);
        }
    }

    private void SkipRound(object sender, EventArgs e)
    {
        //skip the round
        ChangeMessages(1);
        UpdateCombat(4);
    }

    private void Inventory(object sender, EventArgs e)
    {
        //open the inventory
        UpdateCombat(0);
    }

    private async void Leave(object sender, EventArgs e)
    {
        //reduce player ex and leave the battle state
        ChangeMessages(3);
        xp -= 100; //change with real one
        await Task.Delay(2000);
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
        await Task.Delay(2000);
        //reset the player texture
        playerTexture = Globals.Content.Load<Texture2D>("Player/playerIdle");
        enemyTexture = Globals.Content.Load<Texture2D>("Enemy/enemy1");
    }

    private async void ChangeMessages(int message)
    {
        switch (message)
        {
            case 0:
                //error bp
                errorBp = "Not enough BP";
                break;
            case 1:
                //skip
                skip = "You skipped your turn";
                break;
            case 2:
                //next turn
                nextTurn = "Turn over, enemy attacking!";
                break;
            case 3:
                skip = "Leaving combat... Applying XP penalty of 100!";
                break;
            case 4:
                errorBp = "Attack Failed!";
                break;
            case 5:
                errorBp = "Attack Successful!";
                break;
            default:
                errorBp = "";
                skip = "";
                nextTurn = "";
                break;
        }
        await Task.Delay(2000);
        errorBp = "";
        skip = "";
        nextTurn = "";
    }


}

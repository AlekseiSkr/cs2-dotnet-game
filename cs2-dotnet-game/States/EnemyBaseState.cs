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
    private int attackBPCost = 40;
    private int defendBPCost = 20;
    private int attackEfficiency = 35;

    private bool defend = false;

    private int enemyHP = 100;

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

        hp = "HP: ";
        bp = "BP: ";
        sp = "SP: ";
        enemyhp = "HP: ";
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

        hp = "HP: " + gm.player.healthPoints;
        bp = "BP: " + gm.player.battlePoints;
        sp = "SP: " + gm.player.staminaPoints;
        enemyhp = "HP: " + enemyHP;
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
            _gm.player.healthPoints -= (attackEfficiency / 2);
        }
        else
        {
            _gm.player.healthPoints -= 35;
        }
        hp = "HP: " + _gm.player.healthPoints;
        if (_gm.player.healthPoints <= 0)
        {
            await Task.Delay(1000);
            _gm.ChangeState(GameStates.GameOver);
        }
        defend = false;
    }

    private async void Attack(object sender, EventArgs e)
    {
        buttonAttack.Disabled = true;
        buttonAttack.OnClick -= Attack;
        if (_gm.player.battlePoints >= attackBPCost)
        {
            //attack the enemy
            //80% chance of success
            Random rnd = new Random();
            int number = rnd.Next(1, 101);
            if (number < 75)
            {
                UpdateCombat(1);
                _gm.player.battlePoints -= attackBPCost;
                bp = "BP: " + _gm.player.battlePoints;
                enemyHP -= attackEfficiency;
                enemyhp = "HP: " + enemyHP;

                ChangeMessages(5);

                if (enemyHP <= 0)
                {
                    await Task.Delay(2000);
                    ChangeMessages(6);
                    UpdateCombat(8);
                    await Task.Delay(2000);
                    _gm.player.xpPoints += 100;
                    _gm.player.enemiesKilled++;

                    if (_gm.player.enemiesKilled == 1)
                    {
                        _gm.player.keysObtained = 1;
                    }
                    if (_gm.player.enemiesKilled == 15)
                    {
                        _gm.player.keysObtained = 2;
                    }
                    if (_gm.player.enemiesKilled == 20)
                    {
                        _gm.player.keysObtained = 3;
                    }

                    int enemyHealth = rnd.Next(100, 201);
                    enemyHP = enemyHealth;

                    _gm.player.battlePoints = _gm.player.maxBattlePoints;
                    _gm.player.healthPoints = _gm.player.maxHealthPoints;
                    _gm.ChangeState(GameStates.Menu);
                    bp = "BP: " + _gm.player.battlePoints;
                    hp = "HP: " + _gm.player.healthPoints;
                    enemyhp = "HP: " + enemyHP;
                }

                if (_gm.player.battlePoints == 0)
                {
                    await Task.Delay(2000);
                    ChangeMessages(2);
                    //await Task.Delay(2000);
                    _gm.player.battlePoints = 10 * _gm.player.staminaPoints;
                    bp = "BP: " + _gm.player.battlePoints;
                    await Task.Delay(200);
                    EnemyAttack();
                }
            }
            else
            {
                _gm.player.battlePoints -= attackBPCost;
                bp = "BP: " + _gm.player.battlePoints;
                ChangeMessages(4);
                if (_gm.player.battlePoints == 0)
                {
                    await Task.Delay(2000);
                    ChangeMessages(2);
                    //await Task.Delay(2000);
                    _gm.player.battlePoints = 10 * _gm.player.staminaPoints;
                    bp = "BP: " + _gm.player.battlePoints;
                    await Task.Delay(200);
                    EnemyAttack();
                }
            }
        }
        else
        {
            //not enough battle points
            ChangeMessages(0);
        }
        await Task.Delay(2500);
        buttonAttack.Disabled = false;
        buttonAttack.OnClick += Attack;
    }
    private async void AttackSpell(object sender, EventArgs e)
    {
        await Task.Delay(100);
        UpdateCombat(2);
    }

    private async void Defend(object sender, EventArgs e)
    {
        buttonDefend.Disabled = true;
        buttonDefend.OnClick -= Defend;
        await Task.Delay(500);
        //defend against the enemy
        if (_gm.player.battlePoints >= defendBPCost)
        {
            UpdateCombat(3);
            defend = true;
            _gm.player.battlePoints -= defendBPCost;
            if (_gm.player.battlePoints > 0)
            {
                _gm.player.battlePoints = 0;
            }
            bp = "BP: " + _gm.player.battlePoints;
            ChangeMessages(7);

            await Task.Delay(2000);
            _gm.player.battlePoints += 10 * _gm.player.staminaPoints;
            bp = "BP: " + _gm.player.battlePoints;
            EnemyAttack();
        }
        else
        {
            //not enough battle points
            ChangeMessages(0);
        }
        await Task.Delay(2500);
        buttonDefend.Disabled = false;
        buttonDefend.OnClick += Defend;
    }

    private async void SkipRound(object sender, EventArgs e)
    {
        buttonSkipRound.Disabled = true;
        buttonSkipRound.OnClick -= SkipRound;
        //skip the round
        ChangeMessages(1);
        //UpdateCombat(4);
        _gm.player.battlePoints += 10 * _gm.player.staminaPoints;
        if (_gm.player.battlePoints > _gm.player.maxBattlePoints)
        {
            _gm.player.battlePoints = 100;
        }
        bp = "BP: " + _gm.player.battlePoints;
        await Task.Delay(1000);
        EnemyAttack();
        await Task.Delay(2500);
        buttonSkipRound.Disabled = false;
        buttonSkipRound.OnClick += SkipRound;
    }

    private void Inventory(object sender, EventArgs e)
    {
        //open the inventory
        UpdateCombat(0);
    }

    private async void Leave(object sender, EventArgs e)
    {
        buttonLeave.Disabled = true;
        buttonLeave.OnClick -= Leave;
        await Task.Delay(100);
        //reduce player ex and leave the battle state
        ChangeMessages(3);
        _gm.player.xpPoints -= 100;
        await Task.Delay(500);
        _gm.ChangeState(GameStates.Menu);
        await Task.Delay(500);
        buttonLeave.Disabled = false;
        buttonLeave.OnClick += Leave;

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

        //wait for 2 seconds
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
                nextTurn = "Attack Successful!";
                break;
            case 6:
                errorBp = "Enemy defeated!";
                break;
            case 7:
                //next turn
                nextTurn = "Turn over, enemy attacking! You are defending!";
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

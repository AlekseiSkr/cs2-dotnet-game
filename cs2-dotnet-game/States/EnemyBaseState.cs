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
    private int xp  = 0;

    private int enemyHP = 100;
    private int enemyBP = 50;
    private int enemySP = 5;

    private readonly Button buttonLeave;
    private readonly Button buttonAttack;
    private readonly Button buttonDefend;
    private readonly Button buttonSkipRound;
    private readonly Button buttonInventory;

    private Texture2D backgroundTexture;

    private GameManager _gm;


    public EnemyBaseState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>(GetBackground());

        buttonLeave = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 1000));
        //buttonLeave.OnClick += gm.MenuState;
        buttonLeave.OnClick += Leave;
        
        buttonAttack = new(Globals.Content.Load<Texture2D>("Enemy/Attack"), new(300, 850));
        buttonDefend = new(Globals.Content.Load<Texture2D>("Enemy/defend"), new(500, 850));
        buttonSkipRound = new(Globals.Content.Load<Texture2D>("Enemy/143-glossy-round-button-arrow-109083212"), new(700, 850));
        buttonInventory = new(Globals.Content.Load<Texture2D>("Enemy/items"), new(900, 850));
        _gm = gm;
    }
    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
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
        //attack the enemy
    }

    private void Defend(object sender, EventArgs e)
    {
        //defend against the enemy
    }

    private void SkipRound(object sender, EventArgs e)
    {
        //skip the round
    }

    private void Inventory(object sender, EventArgs e)
    {
        //open the inventory
    }

    private void Leave(object sender, EventArgs e)
    {
        //reduce player ex and leave the battle state
        //player.xp -= 100;
        _gm.ChangeState(GameStates.Menu);

    }
    

}

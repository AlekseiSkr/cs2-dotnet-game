using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace cs2_dotnet_game;
public class PlayerBaseState : State
{
    private Texture2D backgroundTexture;
    private Texture2D baseTexture;

    private readonly Button buttonUpdateTier1;
    private readonly Button buttonUpdateTier2;
    private readonly Button buttonLeaveBase;
    private readonly Button buttonSleep;

    private String baseTier = "Current base tier : 1";
    private String baseTierExplanationLine1 = "You can upgrade your base to increase your";
    private String baseTierExplanationLine2 = "maximum health and stamina.";
    private String baseSleepLine1 = "You can sleep at the base to recover your";
    private String baseSleepLine2 = "health and battle points.";
    private String currentHP = "Current HP : 100/100";
    private String currentBP = "Current BP : 100";
    private String currentSP = "Current SP : 4";
    private String currentXP = "Current XP : 1000";


    //temp var till player is implemented
    private int playerXP = 1000;
    private int playerHP = 50;
    private int playerBP = 0;
    private int playerSP = 4;
    private int playerMaxHP = 100;

    private bool update1 = false;
    private bool update2 = false;

    private GameManager _gm;

    public PlayerBaseState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("Misc/background1");
        //generates a rectangle for the background image, centered on the middle
        GenerateRectangleBackground();
        baseTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV1");
        
        buttonUpdateTier1 = new(Globals.Content.Load<Texture2D>("PlayerBase/buttonPlusOne"), new(100, 100));
        buttonUpdateTier1.OnClick += UpdateBase1Event;
        //buttonUpdateTier1.Disabled = true;

        buttonUpdateTier2 = new(Globals.Content.Load<Texture2D>("PlayerBase/buttonPlusTwo"), new (200, 100));
        buttonUpdateTier2.OnClick += UpdateBase2Event;
        //buttonUpdateTier2.Disabled = true;

        buttonLeaveBase = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 1000));
        buttonLeaveBase.OnClick += gm.MenuState;

        buttonSleep = new(Globals.Content.Load<Texture2D>("sleep"), new(130, 700));
        buttonSleep.OnClick += Sleep;

        _gm = gm;

        currentHP = "Current HP : " ;
        currentBP = "Current BP : " ;
        currentSP = "Current SP : " ;
        currentXP = "Current XP : " ;
    }
    
    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
        Globals.SpriteBatch.Draw(baseTexture, backgroundRectangle, Color.White);
        buttonUpdateTier1.Draw();
        buttonUpdateTier2.Draw();
        buttonLeaveBase.Draw();
        buttonSleep.Draw();

        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), baseTier, new Vector2(70, 200), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), baseTierExplanationLine1, new Vector2(70, 240), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), baseTierExplanationLine2, new Vector2(70, 260), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), baseSleepLine1, new Vector2(70, 300), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), baseSleepLine2, new Vector2(70, 320), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), currentHP, new Vector2(70, 360), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), currentBP, new Vector2(70, 400), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), currentSP, new Vector2(70, 440), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), currentXP, new Vector2(70, 480), Color.White);

        currentHP = "Current HP : " + gm.player.healthPoints + "/" + gm.player.maxHealthPoints;
        currentBP = "Current BP : " + gm.player.battlePoints + "/" + gm.player.maxBattlePoints;
        currentSP = "Current SP : " + gm.player.staminaPoints;
        currentXP = "Current XP : " + gm.player.xpPoints;

    }
    public override void Update(GameManager gm)
    {
        if (gm.player.xpPoints >= 500 && !update1)
        {
            buttonUpdateTier1.Update();
        }
        if (gm.player.xpPoints >= 1000 && update1 && !update2)
        {
            buttonUpdateTier2.Update();
        }
        buttonLeaveBase.Update();
        buttonSleep.Update();

    }    

    private void UpdateBase1Event(object sender, EventArgs e)
    {
        UpgradeBase(1);
        update1 = true;
        baseTier = "Current base tier : 2";
        _gm.player.maxHealthPoints = 125;
        _gm.player.staminaPoints = 5;
        currentSP = "Current SP : " + _gm.player.staminaPoints;
        currentHP = "Current HP : " + _gm.player.healthPoints + "/" + _gm.player.maxHealthPoints;

        _gm.player.xpPoints -= 500;
        currentXP = "Current XP : " + _gm.player.xpPoints;
    }
    
    private void UpdateBase2Event(object sender, EventArgs e)
    {
        UpgradeBase(2);
        update2 = true;
        baseTier = "Current base tier : 3";
        _gm.player.maxHealthPoints = 150;
        _gm.player.staminaPoints = 5;
        currentSP = "Current SP : " + _gm.player.staminaPoints;
        currentHP = "Current HP : " + _gm.player.healthPoints + "/" + _gm.player.maxHealthPoints;

        _gm.player.xpPoints -= 500;
        currentXP = "Current XP : " + _gm.player.xpPoints;
    }

    private void UpgradeBase(int upgrade)
    {
        if (upgrade == 1)
        {
            this.baseTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV2");
        }
        else if (upgrade == 2)
        {
            this.baseTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV3");
        }
        else throw new Exception("Invalid upgrade");
    }

    private void Sleep(object sender, EventArgs e)
    {
        //set hp and bp to max
        _gm.player.healthPoints = _gm.player.maxHealthPoints;
        _gm.player.battlePoints = _gm.player.maxBattlePoints;
        currentHP = "Current HP : " + _gm.player.battlePoints + "/" + _gm.player.maxBattlePoints;
        currentHP = "Current HP : " + _gm.player.healthPoints + "/" + _gm.player.maxHealthPoints;
    }
}
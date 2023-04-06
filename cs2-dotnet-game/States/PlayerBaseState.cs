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

    //temp var till player is implemented
    private int playerXP = 1000;
    private bool update1 = false;
    private bool update2 = false;

    public PlayerBaseState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("Misc/background1");
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

    }
    
    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
        Globals.SpriteBatch.Draw(baseTexture, backgroundRectangle, Color.White);
        buttonUpdateTier1.Draw();
        buttonUpdateTier2.Draw();
        buttonLeaveBase.Draw();
    }
    public override void Update(GameManager gm)
    {
        if (playerXP >= 500 && !update1)
        {
            buttonUpdateTier1.Update();
            
        }
        if (playerXP >= 1000 && update1 && !update2)
        {
            buttonUpdateTier2.Update();
            
        }
        buttonLeaveBase.Update();

    }

    //generates a rectangle for the background image, centered on the middle
    

    private void UpdateBase1Event(object sender, EventArgs e)
    {
        UpgradeBase(1);
        update1 = true;
    }

    private void UpdateBase2Event(object sender, EventArgs e)
    {
        UpgradeBase(2);
        update2 = true;
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
}
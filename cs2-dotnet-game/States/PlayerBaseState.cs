using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace cs2_dotnet_game;
public class PlayerBaseState : State
{
    private Texture2D backgroundTexture;

    //1792, 1008
    private int screenWidth = 1792;
    private int screenHeight = 1008;
    private int imageWidth = 800;
    private int imageHeight = 800;
    private int imageX = 0;
    private int imageY = 0;

    private Rectangle backgroundRectangle;
    private Button buttonUpdateTier1;
    private Button buttonUpdateTier2;

    //temp var till player is implemented
    private int playerXP = 1000;
    private bool update1 = false;
    private bool update2 = false;

    public PlayerBaseState(GameManager gm)
    {
        GenerateRectangleBackground();
        backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV1");
        
        buttonUpdateTier1 = new(Globals.Content.Load<Texture2D>("PlayerBase/buttonPlusOne"), new(100, 100));
        buttonUpdateTier1.OnClick += UpdateBase1Event;
        //buttonUpdateTier1.Disabled = true;

        buttonUpdateTier2 = new(Globals.Content.Load<Texture2D>("PlayerBase/buttonPlusTwo"), new (200, 100));
        buttonUpdateTier2.OnClick += UpdateBase2Event;
        //buttonUpdateTier2.Disabled = true;


    }

    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);
        buttonUpdateTier1.Draw();
        buttonUpdateTier2.Draw();
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

    }

    //generates a rectangle for the background image, centered on the middle
    private void GenerateRectangleBackground()
    {
        imageX = (screenWidth - imageWidth) / 2;
        imageY = (screenHeight - imageHeight) / 2;
        backgroundRectangle = new Rectangle(imageX, imageY, imageWidth, imageHeight);
    }

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
            this.backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV2");
        }
        else if (upgrade == 2)
        {
            this.backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV3");
        }
        else throw new Exception("Invalid upgrade");
    }
}
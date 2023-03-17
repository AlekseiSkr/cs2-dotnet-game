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
    //private readonly List<Button> _buttons = new();
    private Button buttonChange;

    public override void Draw(GameManager gm)
    {
        generateRectangle();
        backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV1");

        //spriteBatchPlayerBase.Begin();
        Globals.SpriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);
        //Globals.SpriteBatch.Draw(Globals.Content.Load<Texture2D>("PlayerBase/baseV2"), new Rectangle(0, 500, 300, 300), Color.White);
        buttonChange = new(Globals.Content.Load<Texture2D>("Menu/easy"), new(100, 100));
        //buttonChange.OnClick += updateBase1Event;
        buttonChange.OnClick += gm.start;
        buttonChange.Draw();
        //add other logic here

    }
    public override void update(GameManager gm)
    {
        buttonChange.Update();
    }

    public void generateRectangle()
    {
        imageX = (screenWidth - imageWidth) / 2;
        imageY = (screenHeight - imageHeight) / 2;
        backgroundRectangle = new Rectangle(imageX, imageY, imageWidth, imageHeight);
    }

    public void updateBase1Event(object sender, EventArgs e)
    {
        upgradeBase(1);
    }
  
    public void upgradeBase(int upgrade)
    {
        if (upgrade == 1)
        {
            this.backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV2");
        }
        else if (upgrade == 2)
        {
            this.backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV3");
        }
        else throw new System.Exception("Invalid upgrade");
    }
}
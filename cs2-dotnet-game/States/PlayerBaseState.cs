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

    public PlayerBaseState(GameManager gm)
    {
        GenerateRectangle();
        backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV1");
        buttonChange = new(Globals.Content.Load<Texture2D>("Menu/easy"), new(100, 100));
        buttonChange.OnClick += gm.start;
    }

    public override void Draw(GameManager gm)
    {
        

        //spriteBatchPlayerBase.Begin();
        Globals.SpriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);
        //Globals.SpriteBatch.Draw(Globals.Content.Load<Texture2D>("PlayerBase/baseV2"), new Rectangle(0, 500, 300, 300), Color.White);
        
        //buttonChange.OnClick += updateBase1Event;
       
        buttonChange.Draw();
        //add other logic here

    }
    public override void Update(GameManager gm)
    {
        buttonChange.Update();
    }

    private void GenerateRectangle()
    {
        imageX = (screenWidth - imageWidth) / 2;
        imageY = (screenHeight - imageHeight) / 2;
        backgroundRectangle = new Rectangle(imageX, imageY, imageWidth, imageHeight);
    }

    private void UpdateBase1Event(object sender, EventArgs e)
    {
        UpgradeBase(1);
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
        else throw new System.Exception("Invalid upgrade");
    }
}
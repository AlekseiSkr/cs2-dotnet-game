using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace cs2_dotnet_game;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameManager _gameManager;
    
    public static List<String> playerItems = new List<String>();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        playerItems.Add("Sword");
        playerItems.Add("Shield");
        playerItems.Add("Potion");
    }

    protected override void Initialize()
    {
        Globals.Game = this;
        Globals.Bounds = new(1920, 1080);
        // TODO: Add your initialization logic here

        _graphics.PreferredBackBufferWidth = Globals.Bounds.X;
        _graphics.PreferredBackBufferHeight = Globals.Bounds.Y;
        _graphics.IsFullScreen = false;
        _graphics.HardwareModeSwitch = true;
        _graphics.ApplyChanges();
        Window.Title = "C#2 Resit: Last Elves";
        Globals.Content = Content;
        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        Globals.Update(gameTime);
        _gameManager.Update();

        base.Update(gameTime);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
        Globals.Content = Content;

        _gameManager = new();
    }

    protected override void Draw(GameTime gameTime)
    {
        
        GraphicsDevice.Clear(Color.CornflowerBlue);

        Matrix? transformMatrix = _gameManager.CurrentStateTransformationMatrix;
        if (transformMatrix.HasValue)
        {
            _spriteBatch.Begin(transformMatrix: transformMatrix.Value);
        }
        else
        {
            _spriteBatch.Begin();
        }
        _gameManager.Draw();
        _spriteBatch.End();

        base.Draw(gameTime);


    }
}
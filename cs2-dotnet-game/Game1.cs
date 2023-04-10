using _Models.Sprites;
using _Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace cs2_dotnet_game;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameManager _gameManager;
    private Vector2 _centerScreen
    => new Vector2(_graphics.GraphicsDevice.Viewport.Width / 2f, _graphics.GraphicsDevice.Viewport.Height / 2f);
    private Player player;
    private Settings settings;


    public static List<String> playerItems = new List<String>();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        
    }

    protected override void Initialize()
    {
        Globals.Game = this;
        Globals.Bounds = new(1920, 1080);
        // TODO: Add your initialization logic here

        _graphics.PreferredBackBufferWidth = Globals.Bounds.X;
        _graphics.PreferredBackBufferHeight = Globals.Bounds.Y;
        _graphics.IsFullScreen = true;
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

        InputManager.MouseControl.Update();
        _gameManager.Update();

        if (Globals.DragAndDropPacket != null)
        {
            Globals.DragAndDropPacket.Update();
        }

        InputManager.MouseControl.UpdateOld();

        base.Update(gameTime);
    }

    protected override void LoadContent()
    {
        
        Texture2D texture = Content.Load<Texture2D>("backButton");
        Vector2 position = new Vector2(0, 0);
        List<Item> items = new List<Item>();
        player = new Player(texture, position, "Vlad", 100, 100, 100, 100, 100, items, 100, 100, 100, 100, 100, 1);
        Data data = new Data()
        {
            player = this.player
        };
        data.SaveGame();

        data = Data.LoadGame();

        player = data.player;

        settings = new Settings()
        {
            Volume = 100,
            Language = "en-US"
        };
        settings.SaveSettings();
        this.settings = Settings.LoadSettings();
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
        Globals.Content = Content;


        Globals.CenterScreen = _centerScreen;
        //Globals.DialogFont = Content.Load<SpriteFont>("dialog");

        InputManager.MouseControl = new _Managers.MouseControl();

        _gameManager = new();
        Globals.DragAndDropPacket = new _Models.Sprites.DragAndDropPacket(new Vector2(40, 40));

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
        if (Globals.DragAndDropPacket != null)
        {
            Globals.DragAndDropPacket.Draw();
        }
        _spriteBatch.End();

        base.Draw(gameTime);


    }
}
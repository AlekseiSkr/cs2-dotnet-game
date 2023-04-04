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
    private Player player;
    private Settings settings;


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
        _graphics.ApplyChanges();
        Window.Title = "C#2 Resit: Last Elves";

        Globals.Content = Content;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        
        Texture2D texture = Content.Load<Texture2D>("backButton");
        Vector2 position = new Vector2(0, 0);
        Item item1 = new Item(texture, position, true, 100, _Models.Enums.Tier.Common);
        Item item2 = new Item(texture, position, true, 66, _Models.Enums.Tier.Legendary);
        List<Item> items = new List<Item>() { item1, item2 };
        player = new Player(texture, position, "Vlad", 100, 100, 100, 100, 100, items, 100, 100, 100, 100, 100, 1);
        Data data = new Data()
        {
            player = this.player
        };
        data.SaveGame();

        data = Data.LoadGame();

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

        _gameManager = new();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        Globals.Update(gameTime);
        _gameManager.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _gameManager.Draw();
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void SaveGame(Player pStats)
    { 
        string serializedText = JsonSerializer.Serialize<Player>(pStats);
        Trace.WriteLine(serializedText);
        File.WriteAllText(SAVE_GAME_PATH, serializedText);
    }

    private Player LoadGame()
    { 
        var fileContents = File.ReadAllText(SAVE_GAME_PATH);
        return JsonSerializer.Deserialize<Player>(fileContents);
    }

    private void SaveSettings(Settings settings)
    {
        string serializedText = JsonSerializer.Serialize<Settings>(settings);
        Trace.WriteLine(serializedText);
        File.WriteAllText(SAVE_SETTINGS_PATH, serializedText);
    }

    private Settings LoadSettings()
    {
        var fileContents = File.ReadAllText(SAVE_SETTINGS_PATH);
        return JsonSerializer.Deserialize<Settings>(fileContents);
    }
}
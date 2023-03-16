using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace cs2_dotnet_game;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameManager _gameManager;
    private Player pStats;
    private Settings settings;
    private const string SAVE_GAME_PATH = "stats.json";
    private const string SAVE_SETTINGS_PATH = "settings.json";

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
        pStats = new Player()
        {
            Name = "Test",
            HealthPoints = 100,
            SpellPoints = 50,
            Attack = 4.46,
            items = new List<string>() { "Stick", "Potion" }
        };
        SaveGame(pStats);

        this.pStats = LoadGame();
        Trace.WriteLine($"{pStats.Name} {pStats.HealthPoints} {pStats.SpellPoints} {pStats.Attack} {pStats.items}");

        settings = new Settings()
        {
            Volume = 100,
            Language = "en-US"
        };
        SaveSettings(settings);

        this.settings = LoadSettings();
        Trace.WriteLine($"{settings.Volume} {settings.Language}");


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
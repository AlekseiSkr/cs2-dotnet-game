using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace cs2_dotnet_game;

public class OptionsState : State
{
    private readonly List<Button> _buttons = new();
    private readonly Texture2D backgroundTexture;

    public OptionsState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("Menu/menu_background");
        var r = new Random();
        var x = Globals.Bounds.X / 2;
        var y = Globals.Bounds.Y / 2;

        MenuButton back = new(Globals.Content.Load<Texture2D>("backButton"), new(x - 800, y - 450))
        {
        };

        back.OnClick += gm.MenuState;
        AddButton(SoundManager.vol0);
        AddButton(SoundManager.vol25);
        AddButton(SoundManager.vol50);
        AddButton(SoundManager.vol75);
        AddButton(SoundManager.vol100);
        AddButton(back);
    }

    private Button AddButton(Button button)
    {
        _buttons.Add(button);
        return button;
    }

    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), "Volume:", new Vector2(700, 530), Color.Red);
        foreach (var button in _buttons)
        {
            button.Draw();
        }
    }

    public override void Update(GameManager gm)
    {
        foreach (var button in _buttons)
        {
            button.Update();
        }
    }

    private void SelectVolume(object sender, EventArgs e)
    {
        foreach (var button in _buttons)
        {
            button.Disabled = false;
        }
    }
}

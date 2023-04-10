using cs2_dotnet_game._Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace cs2_dotnet_game;

public static class InputManager
{
    //Keyboard Functionality SETUP

    //public static KeyboardState _lastKeyboadState;
    //private static Point _direction;
    //public static Point Direction => _direction;

    private static Point _direction;
    public static bool MouseClicked { get; private set; }
    public static bool MouseRightClicked { get; private set; }

    public static Point RightClickedPosition { get; private set; }
    public static Point MouseClickedPosition { get; private set; }
    public static Point MousePosition => Mouse.GetState().Position;

    public static Rectangle MouseRectangle { get; private set; }

    public static MouseState LastMouseState { get; private set; }
    public static MouseState LastRightMouseState { get; private set; }
    public static KeyboardState LastKeyboardState { get; set; }
    public static KeyboardState KeyState { get; private set; }
    public static Point Direction => _direction;

    public static MouseControl MouseControl;
    public static float GetDistance(Vector2 position, Vector2 target)
    {
        return (float)Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y + target.Y, 2));
    }
    public static void Update()
    {
        //Keyboard Functionality
        // _direction = Point.Zero;
        //_lastKeyboadState = keyboardState;
        //var keyboardState = Keyboard.GetState();
        var keyboardState = Keyboard.GetState();
        _direction = Point.Zero;

        if (keyboardState.IsKeyDown(Keys.W) && LastKeyboardState.IsKeyUp(Keys.W)) _direction.Y--;
        if (keyboardState.IsKeyDown(Keys.S) && LastKeyboardState.IsKeyUp(Keys.S)) _direction.Y++;
        if (keyboardState.IsKeyDown(Keys.A) && LastKeyboardState.IsKeyUp(Keys.A)) _direction.X--;
        if (keyboardState.IsKeyDown(Keys.D) && LastKeyboardState.IsKeyUp(Keys.D)) _direction.X++;
        LastKeyboardState = KeyState;
        KeyState = Keyboard.GetState();

        var ms = Mouse.GetState();
        var onscreen = ms.X >= 0 && ms.X < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth
                        && ms.Y >= 0 && ms.Y < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferHeight
                        && Globals.Game.IsActive;

        MouseClicked = (LastMouseState.LeftButton == ms.LeftButton && ms.LeftButton != ButtonState.Released);
        MouseRightClicked = (LastMouseState.RightButton == ms.RightButton && ms.RightButton != ButtonState.Released);

        MouseClickedPosition = (MouseClicked) ? ms.Position : LastMouseState.Position;
        RightClickedPosition = (MouseRightClicked) ? ms.Position : LastMouseState.Position;

        //var onscreen = ms.X >= 0 && ms.X < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth
        //                        && ms.Y >= 0 && ms.Y < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferHeight
        //                        && Globals.Game.IsActive;

        //MouseClicked = (ms.LeftButton == ButtonState.Pressed) && (LastMouseState.LeftButton == ButtonState.Released) && onscreen;
        //MouseRightClicked = (ms.RightButton == ButtonState.Pressed) && (LastMouseState.RightButton == ButtonState.Released) && onscreen;
        //LastMouseState = ms;

        LastMouseState = ms;
        MouseRectangle = new(ms.X, ms.Y, 1, 1);

    }
}


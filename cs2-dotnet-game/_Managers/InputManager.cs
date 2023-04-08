using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace cs2_dotnet_game;

public static class InputManager
{
    //Keyboard Functionality SETUP

    //public static KeyboardState _lastKeyboadState;
    //private static Point _direction;
    //public static Point Direction => _direction;


    public static bool MouseClicked { get; private set; }
    public static bool MouseRightClicked { get; private set; }

    public static Point RightClickedPosition { get; private set; }
    public static Point MouseClickedPosition { get; private set; }
    public static Point MousePosition => Mouse.GetState().Position;

    public static Rectangle MouseRectangle { get; private set; }

    public static MouseState LastMouseState { get; private set; }
    public static MouseState LastRightMouseState { get; private set; }


    public static void Update()
    {
        //Keyboard Functionality
        // _direction = Point.Zero;
        //_lastKeyboadState = keyboardState;
        //var keyboardState = Keyboard.GetState();

        var ms = Mouse.GetState();

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


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace cs2_dotnet_game;

public static class InputManager
{
    public static KeyboardState _lastKeyboadState;
    public static bool MouseClicked { get; private set; }
    public static bool MouseRightClicked { get; private set; }
    public static Point RightClickedPosition { get; private set; }
    public static Point MouseClickedPosition { get; private set; }
    public static Rectangle MouseRectangle { get; private set; }
    private static Point _direction;
    public static Point Direction => _direction;
    public static Point MousePosition => Mouse.GetState().Position;

    private static MouseState _lastMouseState;

    public static void Update()
    {

        _direction = Point.Zero;

        var keyboardState = Keyboard.GetState();
        var ms = Mouse.GetState();
        MouseClicked = ms.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released;
        MouseRightClicked = ms.RightButton == ButtonState.Pressed && _lastMouseState.RightButton == ButtonState.Released;

        if (MouseClicked)
        {
            MouseClickedPosition = ms.Position;
            Debug.WriteLine("MouseClicked" + MouseClicked + ", " + MouseClickedPosition);
        }

        if (MouseRightClicked)
        {
            RightClickedPosition = ms.Position;
            Debug.WriteLine("RightClickedPosition" + MouseRightClicked + ", " + RightClickedPosition);
        }

        _lastMouseState = ms;

        _lastKeyboadState = keyboardState;


        var onscreen = ms.X >= 0 && ms.X < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth
                                && ms.Y >= 0 && ms.Y < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferHeight
                                && Globals.Game.IsActive;


        MouseRectangle = new(ms.X, ms.Y, 1, 1);

    }
}


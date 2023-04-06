using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _Managers;

public static class InputManager
{
    private static MouseState _lastMouseState;
    public static bool MouseClicked { get; private set; }
    public static bool MouseRightClicked { get; private set; }
    public static Point RightClickedPosition { get; private set; }
    public static Point MouseClickedPosition { get; private set; }
    public static Rectangle MouseRectangle { get; private set; }

    private static MouseState _lastMouseState;
    public static bool MouseClicked { get; private set; }
    public static bool MouseRightClicked { get; private set; }
    public static Rectangle MouseRectangle { get; private set; }

    public static void Update()
    {
        var mouseState = Mouse.GetState();
        MouseClicked = mouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released;
        MouseRightClicked = mouseState.RightButton == ButtonState.Pressed && _lastMouseState.RightButton == ButtonState.Released;

        if (MouseClicked)
        {
            MouseClickedPosition = mouseState.Position;
        }

        if (MouseRightClicked)
        {
            RightClickedPosition = mouseState.Position;
        }

        _lastMouseState = mouseState;
    }
}


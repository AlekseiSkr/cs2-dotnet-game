using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace cs2_dotnet_game._Manager;

public static class InputManager
{
    private static KeyboardState _lastKeyboadState;
    private static Point _direction;
    public static Point Direction => _direction;
    public static Point MousePosition => Mouse.GetState().Position;

    private static MouseState _lastMouseState;
    public static bool MouseClicked { get; private set; }
    public static bool MouseRightClicked { get; private set; }
    public static Rectangle MouseRectangle { get; private set; }

    public static void Update()
    {
        var keyboardState = Keyboard.GetState();

        _direction = Point.Zero;

        if (keyboardState.IsKeyDown(Keys.W) && _lastKeyboadState.IsKeyUp(Keys.W)) _direction.Y--;
        if (keyboardState.IsKeyDown(Keys.S) && _lastKeyboadState.IsKeyUp(Keys.S)) _direction.Y++;
        if (keyboardState.IsKeyDown(Keys.A) && _lastKeyboadState.IsKeyUp(Keys.A)) _direction.X--;
        if (keyboardState.IsKeyDown(Keys.D) && _lastKeyboadState.IsKeyUp(Keys.D)) _direction.X++;

        _lastKeyboadState = keyboardState;

        var ms = Mouse.GetState();
        var onscreen = ms.X >= 0 && ms.X < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth
                                && ms.Y >= 0 && ms.Y < Globals.SpriteBatch.GraphicsDevice.PresentationParameters.BackBufferHeight
                                && Globals.Game.IsActive;

        MouseClicked = (ms.LeftButton == ButtonState.Pressed) && (_lastMouseState.LeftButton == ButtonState.Released) && onscreen;
        MouseRightClicked = (ms.RightButton == ButtonState.Pressed) && (_lastMouseState.RightButton == ButtonState.Released) && onscreen;
        _lastMouseState = ms;

        MouseRectangle = new(ms.X, ms.Y, 1, 1);
    }
}
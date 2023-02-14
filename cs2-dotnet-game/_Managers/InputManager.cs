using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _Managers;

public static class InputManager
{
    private static KeyboardState _lastKeyboadState;
    private static Point _direction;
    public static Point Direction => _direction;
    public static Point MousePosition => Mouse.GetState().Position;

    public static void Update()
    {
        var keyboardState = Keyboard.GetState();

        _direction = Point.Zero;

        if (keyboardState.IsKeyDown(Keys.W) && _lastKeyboadState.IsKeyUp(Keys.W)) _direction.Y--;
        if (keyboardState.IsKeyDown(Keys.S) && _lastKeyboadState.IsKeyUp(Keys.S)) _direction.Y++;
        if (keyboardState.IsKeyDown(Keys.A) && _lastKeyboadState.IsKeyUp(Keys.A)) _direction.X--;
        if (keyboardState.IsKeyDown(Keys.D) && _lastKeyboadState.IsKeyUp(Keys.D)) _direction.X++;

        _lastKeyboadState = keyboardState;
    }
}
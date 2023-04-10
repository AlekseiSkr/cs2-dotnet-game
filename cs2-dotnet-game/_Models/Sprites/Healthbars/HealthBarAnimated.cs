
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace cs2_dotnet_game;
public class HealthBarAnimated : HealthBar
{
    #region Fields
    private float _targetValue;
    private readonly float _animationSpeed = 20;
    private Rectangle _animationPart;
    private Vector2 _animationPosition;
    private Color _animationShade;
    #endregion

    #region Methods
    public HealthBarAnimated(Texture2D bg, Texture2D fg, float max, Vector2 pos) : base(bg, fg, max, pos)
    {
        _targetValue = max;
        _animationPart = new(foreground.Width, 0, 0, foreground.Height);
        _animationPosition = pos;
        _animationShade = Color.DarkGray;
    }

    public override void Update(float value)
    {
        if (value == currentValue) return;

        _targetValue= value;
        int x;

        if (_targetValue < currentValue)
        {
            currentValue -= _animationSpeed * Globals.TotalSeconds;
            // check if the health is already at min
            if (currentValue < _targetValue) currentValue = _targetValue;
            x = (int)(_targetValue / maxValue * foreground.Width);
            _animationShade = Color.DarkGray;
        }
        else
        {
            currentValue += _animationSpeed * Globals.TotalSeconds;
            // check if the health is already at max
            if (currentValue > _targetValue) currentValue = _targetValue;
            x = (int)(currentValue / maxValue * foreground.Width);
            _animationShade = Color.DarkGray * 0.5f;
        }

        part.Width = x;
        _animationPart.X = x;
        _animationPart.Width = (int)(Math.Abs(currentValue - _targetValue) / maxValue * foreground.Width);
        _animationPosition.X = position.X + x;
    }

    public override void Draw()
    {
        base.Draw();
        Globals.SpriteBatch.Draw(foreground, _animationPosition, _animationPart, _animationShade, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
    }
    #endregion
}

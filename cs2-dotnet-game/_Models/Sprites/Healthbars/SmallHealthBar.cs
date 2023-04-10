#region Using

#endregion
using _Models.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cs2_dotnet_game._Models.Healthbars;
public class SmallHealthBar
{
    #region Fields
    private int _boarder;
    private Basic2D _foreground, _background;
    public Color _color;
    #endregion

    #region Methods
    public SmallHealthBar(Vector2 dimension, int boarder, Color color)
    {
        _boarder = boarder;
        _color = color;

        var foreground = Globals.Content.Load<Texture2D>("Health/solid");
        var background = Globals.Content.Load<Texture2D>("Health/shade");
        _foreground = new Basic2D(foreground, new Vector2(0, 0), new Vector2(dimension.X - boarder * 2, dimension.Y - boarder * 2));
        _background = new Basic2D(background, new Vector2(0, 0), new Vector2(dimension.X, dimension.Y));
    }

    public virtual void Update(float current, float max)
    {
        _foreground._dimension = new Vector2(current / max * (_background._dimension.X - _boarder * 2), _foreground._dimension.Y);
    }

    public virtual void Draw(Vector2 offset)
    {
        _background.Draw(offset, new Vector2(0, 0), Color.Black);
        _foreground.Draw(offset + new Vector2(_boarder, _boarder), new Vector2(0, 0), _color);
    }
    #endregion
}

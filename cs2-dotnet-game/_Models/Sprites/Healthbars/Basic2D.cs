#region Using 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace cs2_dotnet_game._Models.Healthbars;
public class Basic2D
{
    #region Fields
    protected float _rot;
    public Vector2 _position, _dimension;
    protected Texture2D _model;
    #endregion

    #region Methods
    public Basic2D(Texture2D model, Vector2 position, Vector2 dimension)
    {
        _model = model; 
        _position = position;
        _dimension = dimension;
    }

    public virtual void Update(Vector2 offset)
    {

    }

    public virtual void Draw(Vector2 offset)
    {
        if (_model != null)
        {
            Globals.SpriteBatch.Draw(_model, new Rectangle((int)(_position.X + offset.X), (int)(_position.Y + offset.Y), (int)_dimension.X, (int)_dimension.Y), null, Color.White, _rot, new Vector2(_model.Bounds.Width / 2, _model.Bounds.Height / 2), new SpriteEffects(), 0);
        }
    }

    public virtual void Draw(Vector2 offset, Color color)
    {
        if (_model != null)
        {
            Globals.SpriteBatch.Draw(_model, new Rectangle((int)(_position.X + offset.X), (int)(_position.Y + offset.Y), (int)_dimension.X, (int)_dimension.Y), null, color, _rot, new Vector2(_model.Bounds.Width / 2, _model.Bounds.Height / 2), new SpriteEffects(), 0);
        }
    }

    public virtual void Draw(Vector2 offset, Vector2 origin, Color color)
    {
        if (_model != null)
        {
            Globals.SpriteBatch.Draw(_model, new Rectangle((int)(_position.X + offset.X), (int)(_position.Y + offset.Y), (int)_dimension.X, (int)_dimension.Y), null, color, _rot, new Vector2(origin.X, origin.Y), new SpriteEffects(), 0);
        }
    }
    #endregion
}

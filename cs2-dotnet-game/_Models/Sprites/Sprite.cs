using cs2_dotnet_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _Models.Sprites;

public abstract class Sprite
{
    protected Vector2 _position;
    protected Texture2D _texture;
    public Vector2 _origin { get; protected set; }
    public Color _color { get; set; }
    public abstract void Update();
    public abstract void Draw();

    protected Sprite(Texture2D texture, Vector2 position)
    {
        _position = position;
        _origin = Vector2.Zero;
        _color = Color.White;
        _texture = texture;
    }
    public Rectangle Rectangle => new((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);


}
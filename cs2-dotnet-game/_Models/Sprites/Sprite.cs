using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _Models.Sprites;

public abstract class Sprite
{
    protected readonly Texture2D _texture;
    protected Vector2 _position;

    public abstract void Draw();
    public abstract void Update();

    protected Sprite(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
    }
}
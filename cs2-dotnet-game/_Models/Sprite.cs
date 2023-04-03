using cs2_dotnet_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _Models;

public class Sprite
{
    public Texture2D Texture;
    public Vector2 Position { get; protected set; }
    public Vector2 Origin { get; protected set; }
    public Color Color { get; set; }
    public Rectangle Rectangle => new((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

    public Sprite(Texture2D texture, Vector2 position)
    {
        this.Texture = texture;
        Position = position;
        Origin = Vector2.Zero;
        Color = Color.White;
    }

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, null, Color, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }
}
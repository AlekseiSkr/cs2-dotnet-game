using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cs2_dotnet_game;
public class ButtonSprite
{
    public Vector2 Position { get; set; }
    public Texture2D Texture { get; protected set; }
    protected Vector2 origin;
    protected Vector2 scale;
    protected Color color;

    public ButtonSprite(Texture2D tex, Vector2 pos)
    {
        Texture = tex;
        Position= pos;
        origin = new(tex.Width / 2, tex.Height / 2);
        scale = Vector2.One;
        color = Color.White;
    }

    public virtual void Draw()
    {
        Globals.SpriteBatch.Draw(Texture, Position, null, color, 0f, origin, scale, SpriteEffects.None, 1f);
    }
}
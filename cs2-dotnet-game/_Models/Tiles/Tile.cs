using _Managers;
using _Models.Sprites;
using cs2_dotnet_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _Models.Tiles;

public class Tile : Sprite
{
    public bool Blocked { get; set; }
    public bool Path { get; set; }
    private readonly int _mapX;
    private readonly int _mapY;
    protected bool _keyboardSelected;
    protected bool _mouseSelected;
    protected Texture2D _texture;
    protected Vector2 _position;


    public Tile(Texture2D texture, Vector2 position) : base(texture, position)
    {
        _texture = texture;
        _position = position;
    }

    public override void Update()
    {
        if (Pathfinder.Ready() && Rectangle.Contains(InputManager.MouseRectangle))
        {
            if (InputManager.MouseClicked)
            {
                Blocked = !Blocked;
            }

            if (InputManager.MouseRightClicked)
            {
                // Use map coordinates for the goal position in the BFSearch call
                Pathfinder.BFSearch(_mapX, _mapY);
                _color = Color.Blue;
            }
        }
        //Debug for line drawing, delete on release
        else
        {
            _color = Path ? Color.Green : Color.White;
            _color = Blocked ? Color.Red : _color;
        }
    }

    public override void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _position, null, _color, 0f, _origin, 1f, SpriteEffects.None, 0f);
    }
}
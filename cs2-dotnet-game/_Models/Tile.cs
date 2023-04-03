using _Managers;
using cs2_dotnet_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _Models;

public class Tile : Sprite
{
    public bool Blocked { get; set; }
    public bool Path { get; set; }
    private readonly int _mapX;
    private readonly int _mapY;

    public Tile(Texture2D texture, Vector2 position, int mapX, int mapY) : base(texture, position)
    {
        _mapX = mapX;
        _mapY = mapY;
    }

    public void Update()
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
                Color = Color.Blue;
            }
        }
        //Debug for line drawing, delete on release
        else
        {
            Color = Path ? Color.Green : Color.White;
            Color = Blocked ? Color.Red : Color;
        }

    }
}
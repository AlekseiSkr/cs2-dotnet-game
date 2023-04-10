using cs2_dotnet_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Tiles;

public class PlayerBase : Tile
{
    public PlayerBase(Texture2D texture, Vector2 position) : base(texture, position)
    {
        _origin = new Vector2(0, texture.Height / 2);
    }
    public override void Update() { }
    public override void Draw() 
    {
        Globals.SpriteBatch.Draw(_texture, _position, null, _color, 0f, _origin, 1f, SpriteEffects.None, 0f);
    }
}


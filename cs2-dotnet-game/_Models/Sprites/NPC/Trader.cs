using _Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.NPC;

public class Trader : Sprite
{
    private List<Item> items;

    public Trader(Texture2D texture, Vector2 position, List<Item> items) : base(texture, position)
    {
        this.items = items;
    }

    public override void Draw()
    {
    }

    public override void Update()
    {
    }

    public void Trade()
    { 
    }
}

using _Models.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.Items;

public class Item : Sprite
{
    public bool isMelee;
    public double bonusDamage;
    public Tier tierLevel;

    public Item(Texture2D texture, Vector2 position, bool isMelee, double bonusDamage, Tier tierLevel) : base (texture, position)
    {
        this.isMelee = isMelee;
        this.bonusDamage = bonusDamage;
        this.tierLevel = tierLevel;
    }

    public override void Draw()
    {
    }

    public override void Update()
    {
    }
}

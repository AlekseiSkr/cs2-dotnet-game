using _Models.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.Items;

public abstract class Item : Sprite
{
    protected bool isMelee;
    protected double bonusDamage;
    protected Tier tierLevel;

    protected Item(Texture2D texture, Vector2 position, bool isMelee, double bonusDamage, Tier tierLevel) : base (texture, position)
    {
        this.isMelee = isMelee;
        this.bonusDamage = bonusDamage;
        this.tierLevel = tierLevel;
    }
}

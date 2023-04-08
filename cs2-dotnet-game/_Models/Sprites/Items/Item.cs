using _Models.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using _Models.Enums;
using cs2_dotnet_game;
using cs2_dotnet_game._Models.Sprites;
using cs2_dotnet_game._Models.Sprites.Items;
using cs2_dotnet_game.Enum;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _Models.Sprites.Items;

public class Item : Draggable2D
{
    protected bool isMelee;
    protected double bonusDamage;
    protected Tier tierLevel;
    public InventorySlot slot;

    public Item(Texture2D texture, Vector2 position, Vector2 dimension, Vector2 frame, Color color, bool isMelee, double bonusDamage, Tier tierLevel) : base (texture, position, dimension, frame, color)
    {
        this.isMelee = isMelee;
        this.bonusDamage = bonusDamage;
        this.tierLevel = tierLevel;

        _type = ObjectType.InventoryItem;
        slot = null;
    }

    public void Update(Vector2 offset)
    {
        base.Update(offset);
        //_image.Draw(offset);
    }

}

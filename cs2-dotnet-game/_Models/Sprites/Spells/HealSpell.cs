using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.Spells;

public class HealSpell : Spell
{
    private readonly int healingPoint;

    public HealSpell(Texture2D texture, Vector2 position, int manaCost, int healingPoint) : base (texture, position, manaCost)
    {
        this.healingPoint = healingPoint;
    }

    public int Heal()
    { 
        return this.healingPoint;
    }

    public override void Draw()
    {
    }

    public override void Update()
    {
    }
}

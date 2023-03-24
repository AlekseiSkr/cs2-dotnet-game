using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.Spells;

public class AttackSpell : Spell
{
    private readonly int damage;

    public AttackSpell(Texture2D texture, Vector2 position, int manaCost, int damage) : base(texture, position, manaCost)
    {
        this.damage = damage;
    }

    public int Heal()
    {
        return this.damage;
    }

    public override void Draw()
    {
    }

    public override void Update()
    {
    }
}

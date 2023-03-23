using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.Spells;

public class AttackSpell : Spell
{
    private readonly int damage;

    public AttackSpell(int manaCost, int damage) : base(manaCost)
    {
        this.damage = damage;
    }

    public int Heal()
    {
        return this.damage;
    }
}

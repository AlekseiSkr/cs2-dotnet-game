using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.Spells;

public class HealSpell : Spell
{
    private readonly int healingPoint;

    public HealSpell(int manaCost, int healingPoint) : base (manaCost)
    {
        this.healingPoint = healingPoint;
    }

    public int Heal()
    { 
        return this.healingPoint;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.Spells;
public abstract class Spell
{
    protected readonly int manaCost;

    public Spell(int manaCost)
    {
        this.manaCost = manaCost;
    }
}

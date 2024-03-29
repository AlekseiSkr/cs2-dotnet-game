﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.Spells;
public abstract class Spell : Sprite
{
    protected readonly int manaCost;

    public Spell(Texture2D texture, Vector2 position, int manaCost) : base (texture, position)
    {
        this.manaCost = manaCost;
    }
}

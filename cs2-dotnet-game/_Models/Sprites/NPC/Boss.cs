using _Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.NPC;

public class Boss : Enemy
{
    private int fireResistance;

    public Boss(Texture2D texture, Vector2 position, int health, double attack, double defence, int critical, int speed, int fireResistance) : 
        base(texture, position, health, attack, defence, critical, speed)
    {
        this.fireResistance = fireResistance;
    }
}

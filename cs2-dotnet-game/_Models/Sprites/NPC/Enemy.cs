using _Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites.NPC;

public class Enemy : Sprite
{
    protected int health;
    protected double attack;
    protected double defence;
    protected int critical;
    protected int speed;

    public Enemy(Texture2D texture, Vector2 position, int health, double attack, double defence, int critical, int speed) : base(texture, position)
    {
        this.health = health;
        this.attack = attack;
        this.defence = defence;
        this.critical = critical;
        this.speed = speed;
    }

    public override void Draw()
    {
    }

    public override void Update()
    {
    }

}

using _Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites;

public class Player : Sprite
{

    private string name;
    private int heathPoints;
    private int spellPoints;
    private double attack;
    private int critical;
    private List<Item> items;
    private int speed;
    //private HealthBar healthBar;
    private int leadership;
    private int luck;
    private int experience;
    private double gold;
    private int level;

    public Player(Texture2D texture, Vector2 position, string name, int heathPoints, int spellPoints, double attack, int critical, List<Item> items, int speed, int leadership, int luck, int experience, double gold, int level) : base (texture, position)
    {
        this.name = name;
        this.heathPoints = heathPoints;
        this.spellPoints = spellPoints;
        this.attack = attack;
        this.critical = critical;
        this.items = items;
        this.speed = speed;
        this.leadership = leadership;
        this.luck = luck;
        this.experience = experience;
        this.gold = gold;
        this.level = level;
    }

    public override void Draw()
    {
    }

    public override void Update()
    {
    }
}

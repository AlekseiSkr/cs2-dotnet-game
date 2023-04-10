using _Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Models.Sprites;

public class Player : Sprite
{

    public string name;
    public int heathPoints;
    public int staminaPoints;
    public int battlePoints;
    public double attack;
    public int critical;
    public List<Item> items;
    public int speed;
    //private HealthBar healthBar;
    public int leadership;
    public int luck;
    public int experience;
    public double gold;
    public int level;

    [JsonConstructor]
    public Player(Texture2D texture, Vector2 position, string name, int heathPoints, int staminaPoints, int battlePoints, double attack, int critical, List<Item> items, int speed, int leadership, int luck, int experience, double gold, int level) : base (texture, position)
    {
        this.name = name;
        this.heathPoints = heathPoints;
        this.staminaPoints = staminaPoints;
        this.battlePoints = battlePoints;
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

    public Player(Texture2D texture, Vector2 position, Player p) : base(texture, position)
    {
        this.name = p.name;
        this.heathPoints = p.heathPoints;
        this.staminaPoints = p.staminaPoints;
        this.battlePoints = p.battlePoints;
        this.attack = p.attack;
        this.critical = p.critical;
        this.items = p.items;
        this.speed = p.speed;
        this.leadership = p.leadership;
        this.luck = p.luck;
        this.experience = p.experience;
        this.gold = p.gold;
        this.level = p.level;
    }

    public override void Draw()
    {
    }

    public override void Update()
    {
    }
}

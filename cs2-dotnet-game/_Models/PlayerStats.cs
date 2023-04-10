using _Models.Sprites.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;
public class PlayerStats
{
    public String name { get; set; }
    public int healthPoints { get; set; }
    public int maxHealthPoints { get; set; }
    public int battlePoints { get; set; }
    public int maxBattlePoints { get; set; }
    public int staminaPoints { get; set; }
    public int xpPoints { get; set; }
    public int attackEfficiency { get; set; }
    public int enemiesKilled { get; set; }
    public int keysObtained { get; set; }

    public int cricAttack { get; set; }

    public List<Item> items { get; set; } = new List<Item>();

    public PlayerStats()
    {
        name = "Player";
        healthPoints = 100;
        maxHealthPoints = 100;
        battlePoints = 100;
        maxBattlePoints = 100;
        staminaPoints = 4;
        enemiesKilled = 0;
        keysObtained = 0;
        cricAttack = 0;
    }
    [JsonConstructor]
    public PlayerStats(string name, int healthPoints, int maxHealthPoints, int battlePoints, int maxBattlePoints, int staminaPoints, int xpPoints, int attackEfficiency, int enemiesKilled, int keysObtained, int cricAttack, List<Item> items)
    {
        this.name = name;
        this.healthPoints = healthPoints;
        this.maxHealthPoints = maxHealthPoints;
        this.battlePoints = battlePoints;
        this.maxBattlePoints = maxBattlePoints;
        this.staminaPoints = staminaPoints;
        this.xpPoints = xpPoints;
        this.attackEfficiency = attackEfficiency;
        this.enemiesKilled = enemiesKilled;
        this.keysObtained = keysObtained;
        this.cricAttack = cricAttack;
        this.items = items;
    }
}

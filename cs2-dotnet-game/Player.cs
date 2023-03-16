using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;

public class Player
{
    public string Name { get; set; }
    public int HealthPoints { get; set; }
    public int SpellPoints { get; set;}
    public double Attack {get; set;}
    public List<string> items { get; set;}
}

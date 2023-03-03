using _Enum;
using cs2_dotnet_game;
using cs2_dotnet_game._Manager;
using cs2_dotnet_game._State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _Managers;
public static class GameStateManager
{
    public static Dictionary<GameStates, State> States { get; } = new();

    public static void Init(GameManager gm)
    {
        States.Clear();
        States.Add(GameStates.Menu, new MenuState(gm));
    }
}

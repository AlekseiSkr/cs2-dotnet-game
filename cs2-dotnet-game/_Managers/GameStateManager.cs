
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace cs2_dotnet_game;
public static class GameStateManager
{
    public static Dictionary<GameStates, State> States { get; } = new();

    public static void Init(GameManager gm)
    {
        States.Clear();
        States.Add(GameStates.Menu, new MenuState(gm));
        States.Add(GameStates.Play, new PlayState());
    }
}

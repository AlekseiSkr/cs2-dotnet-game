
using cs2_dotnet_game.States;
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
        States.Add(GameStates.Play, new PlayState(gm)); 
        States.Add(GameStates.PlayerBase, new PlayerBaseState(gm));
        States.Add(GameStates.TraderBase, new TraderState(gm));
        States.Add(GameStates.EnemyBase, new EnemyBaseState(gm));
        States.Add(GameStates.BossMansion, new BossMansionState(gm));
        States.Add(GameStates.Boss, new BossState(gm));
        States.Add(GameStates.Trading, new TradingState(gm));
        States.Add(GameStates.Win, new WinState());
        States.Add(GameStates.GameOver, new GameOverState(gm));
        States.Add(GameStates.Splash, new LoadingState(gm));
        States.Add(GameStates.DialogBox, new DialogBoxState(gm));
        States.Add(GameStates.Inventory, new InventoryState(gm));
    }
}

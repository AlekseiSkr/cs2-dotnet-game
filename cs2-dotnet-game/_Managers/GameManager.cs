using _Enum;
using _Managers;
using _Models;
using cs2_dotnet_game._Models;
using System;

namespace cs2_dotnet_game._Manager;

public class GameManager
{
    #region Fields
    //private readonly Map _map;
    public Map _map;
    private State _gameState;
    
    #endregion
    public GameManager()
    {
        _map = new Map();
        GameStateManager.Init(this);
        ChangeState(GameStates.Menu);
    }


    public void start(object sender, EventArgs e)
    {
        _map.Draw();
    }
    public void ChangeState(GameStates states)
    {
        _gameState = GameStateManager.States[states];
    }
    public void Update()
    {
        InputManager.Update();
        //_map.Update();
        _gameState.update(this);
    }

    public void Draw()
    {
        _gameState.Draw(this);
        //_map.Draw();
    }
}
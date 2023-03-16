using Microsoft.Xna.Framework;
using System;

namespace cs2_dotnet_game;

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
        SoundManager.Init();
        GameStateManager.Init(this);
        ChangeState(GameStates.Menu);
    }


    public void start(object sender, EventArgs e)
    {
        ChangeState(GameStates.Play);
    }

    private void quit(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
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
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
        ChangeState(GameStates.PlayerBase);
    }


    public void start(object sender, EventArgs e)
    {
        ChangeState(GameStates.Play);
    }

    public void playerBaseState(object sender, EventArgs e)
    {
        ChangeState(GameStates.PlayerBase);
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
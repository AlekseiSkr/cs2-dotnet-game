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


    public void Start(object sender, EventArgs e)
    {
        ChangeState(GameStates.Play);
    }

    public void PlayerBaseState(object sender, EventArgs e)
    {
        ChangeState(GameStates.PlayerBase);
    }

    public void TraderState(object sender, EventArgs e)
    {
        ChangeState(GameStates.TraderBase);
    }

    public void MenuState(object sender, EventArgs e)
    {
        ChangeState(GameStates.Menu);
    }

    public void ChangeState(GameStates states)
    {
        _gameState = GameStateManager.States[states];
    }

    public void Update()
    {
        InputManager.Update();
        //_map.Update();
        _gameState.Update(this);
    }

    public void Draw()
    {
        _gameState.Draw(this);
        //_map.Draw();
    }
}
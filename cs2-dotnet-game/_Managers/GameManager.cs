using System;
using _Managers;
using _Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cs2_dotnet_game;

public class GameManager
{
   #region Fields
    //private readonly Map _map;
    private State _gameState;
    public Matrix? CurrentStateTransformationMatrix
    {
        get
        {
            if (_gameState != null)
            {
                return _gameState.TransformationMatrix;
            }

            return null;
        }
    }

    #endregion
    public GameManager()
    {
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

    public void BossMansionState(object sender, EventArgs e)
    {
        ChangeState(GameStates.BossMansion);
    }

    public void BossState(object sender, EventArgs e)
    {
        ChangeState(GameStates.Boss);
    }

    public void EnemyState(object sender, EventArgs e)
    {
        ChangeState(GameStates.EnemyBase);
    }

    public void TradingState(object sender, EventArgs e)
    {
        ChangeState(GameStates.Trading);
    }

    public void MenuState(object sender, EventArgs e)
    {
        ChangeState(GameStates.Menu);
    }

    public void ChangeState(GameStates states)
    {
        _gameState = GameStateManager.States[states];
    }

    public void Quit(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }

    public void Update()
    {
        InputManager.Update();
        _gameState.Update(this);
    }

    public void Draw()
    {
        _gameState.Draw(this);
    }
}

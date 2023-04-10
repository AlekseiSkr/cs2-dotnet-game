using System;
using System.Threading.Tasks;
using _Managers;
using _Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cs2_dotnet_game;

public class GameManager
{
    #region Fields
    //private readonly Map _map;
    public PlayerStats player;
    private State _gameState;
    public bool Checked;
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
        ChangeState(GameStates.Splash);
        //ChangeState(GameStates.Menu);
        player = new PlayerStats();
        //player.keysObtained = 3;
        player.xpPoints = 300;
        Checked= false;
    }


    public void Start(object sender, EventArgs e)
    {
        ChangeState(GameStates.Play);
    }

    public async void PlayerBaseState(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ChangeState(GameStates.PlayerBase);
    }

    public async void DialogbBx(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ChangeState(GameStates.DialogBox);
    }


    public async void TraderState(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ChangeState(GameStates.TraderBase);
    }

    public async void BossMansionState(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ChangeState(GameStates.BossMansion);
    }

    public async void BossState(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ChangeState(GameStates.Boss);
    }

    public async void EnemyState(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ChangeState(GameStates.EnemyBase);
    }

    public async void TradingState(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ChangeState(GameStates.Trading);
    }

    public async void MenuState(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ChangeState(GameStates.Menu);
    }

    public void ChangeState(GameStates states)
    {
        _gameState = GameStateManager.States[states];
    }

    public void LoseState(object sender, EventArgs e)
    {
        ChangeState(GameStates.GameOver);
    }

    public void WinState(object sender, EventArgs e)
    {
        ChangeState(GameStates.Win);
    }

    public void Quit(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }

    public void Options(object sender, EventArgs e)
    {
        ChangeState(GameStates.Options);
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

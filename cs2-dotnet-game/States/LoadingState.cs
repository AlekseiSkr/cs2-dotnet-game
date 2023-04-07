#region Using
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Timers;
namespace cs2_dotnet_game;
#endregion
public class LoadingState : State
{
    #region Fields
    private Texture2D _splashImage;
    private readonly HealthBar _process;
    private Timer _timer;
    private float _time;

    #endregion

    #region Properties
    public State nextState { get; set; }
    private GameManager gm;
    #endregion

    #region Methods
    public LoadingState(GameManager gm) 
    {
        _time = 0.0f;
        _splashImage = Globals.Content.Load<Texture2D>("Menu/splashImage");
        _timer = new(15000);
        var back = Globals.Content.Load<Texture2D>("Health/back");
        var front = Globals.Content.Load<Texture2D>("Health/front");
        _process = new(back, front, 100f, new(650, 950));
        _timer.Interval = 1000;
        _timer.Start();
    }
    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(_splashImage, new Rectangle(0, 0, 1920, 1080), Color.White);
        _process.Draw();
    }

    public void handleTimer(object sender, EventArgs e)
    {
        if (_time > 100f)
        {
            _time = 100f;
        }
        _time += 0.1f;
    }

    public void timerHasElapsed(object sender, EventArgs e)
    {
        _time += 0.1f;
    }
    public override void Update(GameManager gm)
    {
        if (_time >= 100f)
        {
            _timer.Stop();
            _timer.Dispose();
            gm.ChangeState(GameStates.Menu);
        }
        _process.Update(_time);
        _timer.Elapsed += handleTimer;
    }
    #endregion
}

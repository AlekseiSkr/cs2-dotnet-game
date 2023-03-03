using _Managers;
using cs2_dotnet_game._Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _States;
public class PlayState : State
{
    public override void update(GameManager gm)
    {
        gm._map.Update();
    }

    public override void Draw(GameManager gm)
    {
        gm._map.Draw();
    }
}

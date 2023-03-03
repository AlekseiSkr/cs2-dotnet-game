using _Managers;
using cs2_dotnet_game._Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public abstract class State
{
    #region Methods
    // gm is to access necessary data
    public abstract void update(GameManager gm);
    public abstract void Draw(GameManager gm);
    #endregion
}

using cs2_dotnet_game;

public abstract class State
{
    #region Methods
    // gm is to access necessary data
    public abstract void update(GameManager gm);
    public abstract void Draw(GameManager gm);
    #endregion
}

namespace cs2_dotnet_game;
public class PlayState : State
{
    public override void Update(GameManager gm)
    {
        gm._map.Update();
    }

    public override void Draw(GameManager gm)
    {
        gm._map.Draw();
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cs2_dotnet_game;
public class PlayerBaseState : State
{
    private Texture2D backgroundTexture;
    private SpriteBatch spriteBatchPlayerBase;
    public override void update(GameManager gm)
    {

    }

    public override void Draw(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV1");

        spriteBatchPlayerBase.Begin();
        spriteBatchPlayerBase.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
        //add other logic here
        spriteBatchPlayerBase.End();
    }

    public void upgradeBase(int upgrade)
    {
        if (upgrade == 1)
        {
            this.backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV2");
        }
        else if (upgrade == 2)
        {
            this.backgroundTexture = Globals.Content.Load<Texture2D>("PlayerBase/baseV3");
        }
        else throw new System.Exception("Invalid upgrade");
    }
}
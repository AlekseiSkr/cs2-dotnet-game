using cs2_dotnet_game;
using Microsoft.Xna.Framework;

public abstract class State
{
    //1792, 1008
    public Matrix? TransformationMatrix { get; protected set; } = null;
    protected int screenWidth = 1792;
    protected int screenHeight = 1008;
    protected int imageWidth = 800;
    protected int imageHeight = 800;
    protected int imageX = 0;
    protected int imageY = 0;

    protected Rectangle backgroundRectangle;

    #region Methods
    // gm is to access necessary data
    public abstract void Update(GameManager gm);
    public abstract void Draw(GameManager gm);

    protected void GenerateRectangleBackground()
    {
        imageX = (screenWidth - imageWidth) / 2;
        imageY = (screenHeight - imageHeight) / 2;
        backgroundRectangle = new Rectangle(imageX, imageY, imageWidth, imageHeight);
    }
    #endregion
}

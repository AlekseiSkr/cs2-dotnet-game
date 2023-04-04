using cs2_dotnet_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _Managers
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Update(Vector2 position, int screenWidth, int screenHeight, Texture2D heroTexture)
        {
            Transform = Matrix.CreateTranslation(-(int)position.X - heroTexture.Width / 2 + 1920 / 2, -(int)position.Y - heroTexture.Height / 2 + 1080 / 2, 0);
        }
    }
}
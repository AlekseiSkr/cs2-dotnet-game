using Microsoft.Xna.Framework;

namespace _Managers
{
    public class Camera
    {
        public Matrix Transform { get; private set; }

        public void Update(Vector2 position, int screenWidth, int screenHeight)
        {
            Transform = Matrix.CreateTranslation(-(int)position.X/ 2 + screenWidth / 2, -(int)position.Y/2 + screenHeight / 2, 0);
        }

    }
}
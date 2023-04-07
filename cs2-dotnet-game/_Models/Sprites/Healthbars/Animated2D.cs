#region Using
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace cs2_dotnet_game._Models.Healthbars
{
    public class Animated2D : Basic2D
    {
        #region Fields
        private Vector2 _frames;
        private Color _color;
        private bool _frameAnimations;
        private int _currentAnimation = 0;
        private Vector2 _frameSize;
        #endregion

        #region Methods
        public Animated2D(Texture2D texture, Vector2 position, Vector2 dimension, Vector2 frame, Color color) : base(texture, position, dimension)
        {
            _position = new Vector2(position.X, position.Y);
            _dimension = new Vector2(dimension.X, dimension.Y);
            if(_model != null)
            {
                _frameSize = new Vector2(_model.Bounds.Width / frame.X, _model.Bounds.Height / frame.Y);
            }
            _frames = new Vector2(frame.X, frame.Y);    
            _color = color;
        }

        public override void Update(Vector2 offset)
        {

            base.Update(offset);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
        #endregion
    }
}

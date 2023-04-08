#region Using
using _Models.Sprites;
using cs2_dotnet_game.Enum;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

#endregion

namespace cs2_dotnet_game._Models.Sprites
{
    public class DragAndDropPacket
    {
        #region Fields
        private Vector2 _maxDimension;
        public object _item;
        public ObjectType _type;

        private Animated2D _icon;
        #endregion

        #region Methods
        public DragAndDropPacket(Vector2 maxDim)
        {
            _maxDimension= maxDim;
        }

        public virtual void Update()
        {
            if (InputManager.MouseControl.LeftClickRelease())
            {
                _item = null;
                _type = ObjectType.Null;
                _icon = null;
            }
        }

        public virtual void Draw()
        {
            if (_icon != null)
            {
                _icon.Draw(new Vector2(InputManager.MouseControl.newMousePos.X, InputManager.MouseControl.newMousePos.Y), new Vector2(0, 0), Color.White);
            }
        }

        public virtual void SetItem(object item, ObjectType type, Texture2D texture)
        {
            _item = item;
            _type = type;

            if (texture != null)
            {
                _icon = new Animated2D(texture, new Vector2(0, 0), _maxDimension, new Vector2(1, 1), Color.White);
            }
            else
            {
                _icon = null;
            }
        }

        public virtual bool IsDropped()
        {
            if (InputManager.MouseControl.LeftClickRelease())
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}

#region Using
using _Models.Sprites;
using cs2_dotnet_game.Enum;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace cs2_dotnet_game._Models.Sprites
{
    public class Draggable2D : Animated2D
    {
        #region Fields
        private bool _draggable;
        public ObjectType _type;
        
        #endregion

        #region Methods
        public Draggable2D(Texture2D texture, Vector2 position, Vector2 dimension, Vector2 frames, Color color) : base(texture, position, dimension, frames, color)
        {
            _type = ObjectType.Draggable;
        }
        public override void Update(Vector2 offset)
        {
            base.Update(offset);

            if (HoverFirst(offset) && InputManager.MouseControl.LeftClickHold() && InputManager.GetDistance(InputManager.MouseControl.firstMousePos, InputManager.MouseControl.newMousePos) > 15)
            {
                Globals.DragAndDropPacket.SetItem(this, _type, _model);
            }
        }
        #endregion
    }
}

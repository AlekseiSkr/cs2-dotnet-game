#region Using
using _Models.Sprites;
using _Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace cs2_dotnet_game._Models.Sprites.Items
{
    public class InventorySlot : Animated2D
    {
        #region Fields
        public Item _item;
        #endregion

        #region Methods
        public InventorySlot(Vector2 position, Vector2 dimension) : base(Globals.Content.Load<Texture2D>("Health/solid"), position, dimension, new Vector2(1, 1), Color.Gray)
        {

        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset, Color.Gray);
            if (_item != null)
            {
                _item.Draw(offset);
            }
            //Globals.SpriteBatch.Draw(_pic, new(100, 100), new Rectangle(100, 200, 40, 30), Color.White);
        }

        public override void Update(Vector2 offset)
        {
            base.Update(offset);

            if (_item != null)
            {
                _item.Update(offset);
            }

            if (Globals.DragAndDropPacket != null && Globals.DragAndDropPacket._type == Enum.ObjectType.InventoryItem && Globals.DragAndDropPacket.IsDropped() && Hover(offset))
            {
                TransferItem((Item) Globals.DragAndDropPacket._item);
            }
        }

        public virtual void TransferItem(Item item)
        {
            if (item != null)
            {
                Item oldItem = item;
                InventorySlot oldSlot = item.slot;
                Item currenItem = _item;

                _item = item;
                item.slot = this;

                oldSlot._item = currenItem;
                oldItem = currenItem;
            }
        }

        public void addItem(Item item)
        {
            _item = item;
        }
        
        #endregion
    }
}

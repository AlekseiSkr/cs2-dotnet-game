using _Models.Sprites.Items;
using cs2_dotnet_game._Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game._Models
{
    public class FightInventoryMenu
    {
        public bool Active;
        public bool Checked;

        private List<InventorySlot> _inventorySlots;
        private Rectangle _backgroundRectangle;
        private Texture2D _background;

        private MenuButton _useButton;
        private GameManager gm;

        private Item selectedItem;
        public FightInventoryMenu(GameManager gameManager) 
        {
            Active = false;
            Checked = false;

            _inventorySlots= new List<InventorySlot>();

            for (int i = 0; i < 42; i++)
            {
                _inventorySlots.Add(new InventorySlot(new Vector2(0, 0), new Vector2(40, 40)));
            }


            _background = Globals.Content.Load<Texture2D>("Health/solid");

            _backgroundRectangle = new Rectangle(750, 200, 380, 700);

            _useButton = new(Globals.Content.Load<Texture2D>("Menu/simple_button"), new(850, 900))
            {
                Text = "Use"
            };
            _useButton.OnClick += UseItem;
            gm = gameManager;
            selectedItem = null;
        }

        public void checkItem(GameManager gm)
        {
            if (!Checked)
            {
                foreach(var item in gm.player.items)
                {
                    addItem(item);
                }
                Checked = true;
            }
        }

        public void UseItem(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                gm.player.healthPoints += 10;
                discardItem();

                selectedItem = null;
            }
        }

        public void discardItem()
        {
            foreach (var sloth in _inventorySlots)
            {
                if (sloth._item == selectedItem)
                {
                    var item = sloth._item;
                    sloth._item = null;
                    item.slot = null;
                    return;
                }
            }
        }

        public InventorySlot addItem(Item item)
        {
            foreach (var slot in _inventorySlots)
            {
                if (slot._item == null)
                {
                    slot.addItem(item);
                    item.slot = slot;
                    return slot;
                }
            }
            return null;
        }

        public void Draw()
        {
            if (Active)
            {
                Globals.SpriteBatch.Draw(_background, _backgroundRectangle, Color.White);

                for (int i = 0; i < _inventorySlots.Count; i++)
                {
                    Vector2 tempVec = new Vector2(40 + 54 * (int)(i % 6), 300 + 54 * (int)(i / 6));
                    Vector2 topLeft = new(765, 100);
                    _inventorySlots[i].Draw(topLeft + tempVec);
                }

                _useButton.Draw();

            }
        }

        public void selectItem()
        {
            if (Globals.DragAndDropPacket != null && Globals.DragAndDropPacket._type == Enum.ObjectType.InventoryItem && Globals.DragAndDropPacket.IsDropped() && !_backgroundRectangle.Contains(InputManager.MouseRectangle))
            {
                foreach (var sloth in _inventorySlots)
                {
                    if (sloth._item == Globals.DragAndDropPacket._item)
                    {
                        var item = sloth._item;
                        selectedItem = item;
                        return;
                    }
                }
            }
        }

        public void Update()
        {
            if (Active)
            {
                for (int i = 0; i < _inventorySlots.Count; i++)
                {
                    Vector2 tempVec = new Vector2(40 + 54 * (int)(i % 6), 300 + 54 * (int)(i / 6));
                    Vector2 topLeft = new(765, 100);
                    _inventorySlots[i].Update(topLeft + tempVec);
                }

                _useButton.Update();
                selectItem();
            }
            checkItem(gm);
        }
    }
}

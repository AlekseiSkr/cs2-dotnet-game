using _Models.Enums;
using _Models.Sprites.Items;
using cs2_dotnet_game._Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game._Models.Trader
{
    public class TraderMenu
{
        private Texture2D _background;
        private List<InventorySlot> _inventorySlots;
        private Rectangle _backgroundRectangle;

        private MenuButton _traderInventoryButton;

        private bool active;

        public Item selectedItem;

        public string[] itemName = { "Pearl", "Armor", "Sword", "Axe", "Bag", "Boots", "Bow", "Bowstring", "BurningSword", "Charm", "Clover", "Cowl", "Gloves",
                "Helm", "Hourglass", "Lootbag", "Necklace", "Orb", "Ring", "Shield", "Spyglass", "Statue", "Sword", "Tome", "Vial" };

        public TraderMenu()
        {
            _background = Globals.Content.Load<Texture2D>("Health/solid");

            _inventorySlots= new List<InventorySlot>();

            for (int i = 0; i < 25; i++)
            {
                _inventorySlots.Add(new InventorySlot(new Vector2(0, 0), new Vector2(40, 40)));
            }

            _backgroundRectangle = new Rectangle(350, 200, 380, 700);

            _traderInventoryButton = new(Globals.Content.Load<Texture2D>("Menu/simple_button"), new(300, Globals.ScreenHeight - 60))
            {
                Text = "Trader"
            };

            _traderInventoryButton.OnClick += Activate;

            active = false;



            for (int i = 0; i < itemName.Length; i++)
            {
                var item = new Item(Globals.Content.Load<Texture2D>("Item/" + itemName[i].ToString()), new Vector2(0, 0), new Vector2(32, 32), new Vector2(1, 1), Color.White, false, 200, Tier.Common);

                if(itemName[i].ToString() == "Bow" || itemName[i].ToString() == "BurningSword" || itemName[i].ToString() == "Sword")
                {
                    item.isMelee = true;
                }

                addItem(item);
            }
        }
        

        public void permanentItem()
        {
            for(int i = 0; i < itemName.Length; i++)
            {
                if (_inventorySlots[i]._item == null)
                {
                    var item = new Item(Globals.Content.Load<Texture2D>("Item/" + itemName[i].ToString()), new Vector2(0, 0), new Vector2(32, 32), new Vector2(1, 1), Color.White, false, 200, Tier.Common);

                    addItem(item);
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

        public void Activate(object sender, EventArgs e)
        {
            active = ! active;
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
            if (active)
            {
                for (int i = 0; i < _inventorySlots.Count; i++)
                {
                    Vector2 tempVec = new Vector2(40 + 54 * (int)(i % 6), 300 + 54 * (int)(i / 6));
                    Vector2 topLeft = new(375, 100);
                    _inventorySlots[i].Update(topLeft + tempVec);

                    if (_inventorySlots[i].Hover(new Vector2(InputManager.MouseControl.newMousePos.X, InputManager.MouseControl.newMousePos.Y))&& InputManager.MouseControl.LeftClickRelease())
                    {
                        selectedItem = _inventorySlots[i]._item;
                    }
                }
                selectItem();
                permanentItem();
            }

            _traderInventoryButton.Update();
        }

        public void Draw()
        {
            if (active)
            {

                Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), "Trader items", new Vector2(420, 100), Color.Purple);
                Globals.SpriteBatch.Draw(_background, _backgroundRectangle, Color.White);

                for (int i = 0; i < _inventorySlots.Count; i++)
                {
                    Vector2 tempVec = new Vector2(40 + 54 * (int)(i % 6), 300 + 54 * (int)(i / 6));
                    Vector2 topLeft = new(375, 100);
                    _inventorySlots[i].Draw(topLeft + tempVec);
                }
            }

            _traderInventoryButton.Draw();
        }
}
}

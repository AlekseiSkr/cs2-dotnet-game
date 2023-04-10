using _Models.Enums;
using _Models.Sprites.Items;
using cs2_dotnet_game._Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace cs2_dotnet_game._Models.Trader
{
    public class PlayerMenu
    {
        private MenuButton _menuButton;
        public List<InventorySlot> _inventorySlots;
        private bool _activate;

        private Texture2D _background;
        public Rectangle _backgroundRectangle;
        private GameManager gm;
        public bool Checked;
        public PlayerMenu(GameManager gameManager)
        {
            _menuButton = new(Globals.Content.Load<Texture2D>("Menu/simple_button"), new Vector2(Globals.ScreenWidth - 50, Globals.ScreenHeight - 40))
            {
                Text = "Inventory"
            };
            _menuButton.OnClick += Activate;

            _activate = false;


            _backgroundRectangle = new Rectangle(1200, 200, 380, 700);
            _background = Globals.Content.Load<Texture2D>("Health/solid");
            _inventorySlots = new List<InventorySlot>();

            for (int i = 0; i < 42; i++)
            {
                _inventorySlots.Add(new InventorySlot(new Vector2(850, 0), new Vector2(40, 40)));
            }

            gm = gameManager;
            Checked = gameManager.Checked;

        }

        public int getHowManyItem()
        {
            int i = 0;
            foreach(var item in _inventorySlots)
            {
                if (item._item != null)
                {
                    i++;
                }
            }
            return i;
        }

        public void checkItem()
        {
            if (!Checked)
            {
                foreach (var item in gm.player.items)
                {
                    addItem(item);
                }
                Checked = true;
            }
        }

        public async void Activate(object sender, EventArgs e)
        {
            _activate = !_activate;
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
        public void Update()
        {
            if (_activate)
            {
                for (int i = 0; i < _inventorySlots.Count; i++)
                {
                    Vector2 tempVec = new Vector2(40 + 54 * (int)(i % 6), 300 + 54 * (int)(i / 6));
                    Vector2 topLeft = new(360, 100);
                    _inventorySlots[i].Update2(topLeft + tempVec);
                    if (_inventorySlots[i]._item != null)
                    {
                        topLeft = new(1210, 100);
                        _inventorySlots[i]._item.Update(topLeft + tempVec);
                    }
                }
            }
            _menuButton.Update();
            checkItem();
        }

        public void Draw()
        {
            if (_activate)
            {

                Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), "Player items", new Vector2(1300, 100), Color.Purple);
                Globals.SpriteBatch.Draw(_background, _backgroundRectangle, Color.White);

                for (int i = 0; i < _inventorySlots.Count; i++)
                {
                    Vector2 tempVec = new Vector2(40 + 54 * (int)(i % 6), 300 + 54 * (int)(i / 6));
                    Vector2 topLeft = new(360, 100);
                    _inventorySlots[i].Draw2(topLeft + tempVec);
                    if (_inventorySlots[i]._item != null)
                    { 
                       topLeft = new(1210, 100);
                        _inventorySlots[i]._item.Draw(topLeft + tempVec);
                    }
                }
            }
            _menuButton.Draw();
        }



    }
}

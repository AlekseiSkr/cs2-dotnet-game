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

        public TraderMenu()
        {
            _background = Globals.Content.Load<Texture2D>("Health/solid");

            _inventorySlots= new List<InventorySlot>();

            for (int i = 0; i < 42; i++)
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
        }


        public async void Activate(object sender, EventArgs e)
        {
            active = ! active;
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
                }
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

using _Models.Enums;
using _Models.Sprites.Items;
using cs2_dotnet_game._Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game.States
{
    public class InventoryState : State
    {
        private InventoryMenu _invetory;
        public InventoryState(GameManager gm)
        {

            _invetory = new InventoryMenu();

            var item = new Item(Globals.Content.Load<Texture2D>("Item/Pearl"), new Vector2(0, 0), new Vector2(32, 32), new Vector2(1, 1), Color.White, false, 200, Tier.Common);
            var item2 = new Item(Globals.Content.Load<Texture2D>("Item/Sword"), new Vector2(0, 0), new Vector2(32, 32), new Vector2(1, 1), Color.White, false, 200, Tier.Common);

            addItemToPlayer(item);
            addItemToPlayer(item2);

        }

        public override void Update(GameManager gm)
        {
            if (InputManager.KeyState.IsKeyDown(Keys.P))
            {
                gm.ChangeState(GameStates.Play);
            }
            _invetory.Update();
        }

        public override void Draw(GameManager gm)
        {

            _invetory.Draw();
        }


        public void addItemToPlayer(Item item)
        {
            var emptySlot = _invetory.addItem(item);
            if (emptySlot != null)
            {

                item.slot = emptySlot;
            }
        }
    }
}

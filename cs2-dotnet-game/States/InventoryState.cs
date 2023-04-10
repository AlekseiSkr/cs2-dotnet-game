using _Models.Enums;
using _Models.Sprites.Items;
using cs2_dotnet_game._Models;
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
        private GameManager _gm;
        private bool Checked;
        public InventoryState(GameManager gm)
        {

            _invetory = new InventoryMenu();
            _gm = gm;

            Checked = gm.Checked;
        }

        public void check(GameManager gm)
        {
            Checked = gm.Checked;
            if (!Checked)
            {
                foreach (var item in _gm.player.items)
                {
                    addItemToPlayer(item);
                }
                Checked = true;
            }
        }

        public override void Update(GameManager gm)
        {
            check(gm);
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

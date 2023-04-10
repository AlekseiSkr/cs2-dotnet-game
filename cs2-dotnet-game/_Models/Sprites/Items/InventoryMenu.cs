#region Using
using _Models.Enums;
using _Models.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cs2_dotnet_game._Models.Sprites.Items;
#endregion
public class InventoryMenu
{
    #region Fields
    private bool _active;
    private Texture2D _background;
    private MenuButton _closeButton;
    private MenuButton _inventoryButton;
    private List<InventorySlot> _inventorySlots;
    private Rectangle _backgroundRectangle;
    #endregion

    #region Methods
    public InventoryMenu()
    {
        _active = false;
        _background = Globals.Content.Load<Texture2D>("Health/solid");
        /*_inventoryButton = new(Globals.Content.Load<Texture2D>("Menu/simple_button"), new(Globals.Bounds.X - 100, Globals.Bounds.Y - 40))
        {
            Text = "Inventory"
        };*/
        _inventoryButton = new(Globals.Content.Load<Texture2D>("Menu/simple_button"), new(Globals.ScreenWidth - 100, Globals.ScreenHeight - 40))
        {
            Text = "Inventory"
        };
        _inventoryButton.OnClick += Activate;

        _closeButton = new(Globals.Content.Load<Texture2D>("Menu/XButton"), new Vector2(1190, 260));
        _closeButton.OnClick += Activate;

        _backgroundRectangle = new Rectangle(750, 200, 380, 700);



        //var item = new Item(Globals.Content.Load<Texture2D>("Item/Item1"), new(200, 100), false, 200, Tier.Common);
        //var item2 = new Item(Globals.Content.Load<Texture2D>("Item/LootBag"), new(200, 100), false, 200, Tier.Legendary);
        _inventorySlots = new List<InventorySlot>();

        for (int i = 0; i < 42; i++)
        {
            _inventorySlots.Add(new InventorySlot(new Vector2(0, 0), new Vector2(40, 40)));
        }


/*        _inventorySlots[1].addItem(item2);
        item2.slot = _inventorySlots[1];

        _inventorySlots[2].addItem(item3);
        item3.slot = _inventorySlots[2];

        _inventorySlots[3].addItem(item4);
        item4.slot = _inventorySlots[3];*/
    }

    public InventorySlot addItem(Item item)
    {
        foreach(var slot in _inventorySlots)
        {
            if (slot._item == null)
            {
                slot.addItem(item);
                return slot;
            }
        }
        return null;
    }
    public async void Activate(object sender, EventArgs e)
    {
        _active = !_active;
    }

    public virtual void Draw()
    {
        if (_active)
        {
            Globals.SpriteBatch.Draw(_background, _backgroundRectangle, Color.White);
            _closeButton.Draw();

            for(int i = 0; i < _inventorySlots.Count; i++)
            {
                Vector2 tempVec = new Vector2(40 + 54 * (int)(i%6), 300 + 54 * (int)(i/6));
                Vector2 topLeft = new(765, 100);
                _inventorySlots[i].Draw(topLeft + tempVec);
            }


        }
        _inventoryButton.Draw();
    }

    public void discardItem()
    {
        if (Globals.DragAndDropPacket != null && Globals.DragAndDropPacket._type == Enum.ObjectType.InventoryItem && Globals.DragAndDropPacket.IsDropped() && ! _backgroundRectangle.Contains(InputManager.MouseRectangle))
        {
            foreach (var sloth in _inventorySlots)
            {
                if (sloth._item == Globals.DragAndDropPacket._item)
                {
                    var item = sloth._item;
                    sloth._item = null;
                    item.slot = null;
                    return;
                }
            }

        }
    }


    public virtual void Update()
    {
        if (_active)
        {
            _closeButton.Update();

            for (int i = 0; i < _inventorySlots.Count; i++)
            {
                Vector2 tempVec = new Vector2(40 + 54 * (int)(i % 6), 300 + 54 * (int)(i / 6));
                Vector2 topLeft = new(765, 100);
                _inventorySlots[i].Update(topLeft + tempVec);
            }


            discardItem();
        }

        _inventoryButton.Update();
    }
    #endregion

}

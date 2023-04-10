using _Models.Sprites;
using _Models.Sprites.Items;
using cs2_dotnet_game._Models;
using cs2_dotnet_game._Models.Sprites.Items;
using cs2_dotnet_game._Models.Trader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;

public class TraderState : State
{
    private Texture2D backgroundTexture;
    private Texture2D traderTexture;

    private readonly Button buttonTrade;
    private readonly Button buttonLeaveTrader;

    private TraderMenu traderMenu;
    private PlayerMenu _playerMenu;


    //temp var till player & trader is implemented
    private int playerXP = 1000;
    private List<String> playerInventory = new();
    private List<String> traderInventory = new();
    private GameManager _gameManager;

    private string message;

    private int checkItem1;

    public TraderState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("Misc/background2");
        GenerateRectangleBackground();
        traderTexture = Globals.Content.Load<Texture2D>("Trader/traderGuns");

        buttonTrade = new(Globals.Content.Load<Texture2D>("Trader/tradeButton"), new(100, 500));
        buttonTrade.OnClick += Buy;

        buttonLeaveTrader = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 1000));
        buttonLeaveTrader.OnClick += Leaving;

        traderMenu = new TraderMenu();
        _playerMenu = new PlayerMenu(gm);


        //int inventoryWidth = screenWidth / 2 - 20;
        //int inventoryHeight = screenHeight - 40;
        //playerInventoryRectangle = new Rectangle(10, 10, inventoryWidth, inventoryHeight);
        //traderInventoryRectangle = new Rectangle(screenWidth / 2 + 10, 10, inventoryWidth, inventoryHeight);
        _gameManager = gm;

        message = "";
        checkItem1 = 0;
    }

    public void Leaving(object sender, EventArgs e)
    {
        _gameManager.ChangeState(GameStates.Menu);
    }

    public void Buy(object sender, EventArgs e)
    {
        if (_gameManager.player.xpPoints < 20)
        {
            message = "Not enough xp to buy items!";
            return;
        }

        if (traderMenu.selectedItem != null)
        {
            addItem(traderMenu.selectedItem);
            _gameManager.player.items.Add(traderMenu.selectedItem);
            _gameManager.Checked = false;
            _gameManager.player.xpPoints -= 30;
        }
    }

    public void buy2()
    {

        if (Globals.DragAndDropPacket != null && checkItem1 != _playerMenu.getHowManyItem() && Globals.DragAndDropPacket._type == Enum.ObjectType.InventoryItem && Globals.DragAndDropPacket.IsDropped() && _playerMenu._backgroundRectangle.Contains(InputManager.MouseRectangle))
        {
            if (_gameManager.player.xpPoints < 30)
            {
                message = "Not enough xp to buy items!";
                InventorySlot slot = null;
                foreach (var j in _playerMenu._inventorySlots)
                {
                    if (j._item != null)
                    {
                        slot = j;
                    }
                }
                Item item = slot._item;
                slot._item = null;
                item.slot = null;
                checkItem1 = _playerMenu.getHowManyItem();
            }
            else
            {
                _gameManager.player.items.Add((Item)Globals.DragAndDropPacket._item);
                _gameManager.player.xpPoints -= 30;
            }
        }
    }

    public InventorySlot addItem(Item item)
    {
        foreach (var slot in _playerMenu._inventorySlots)
        {
            if (slot._item == null)
            {
                slot.addItem(item);
                return slot;
            }
        }
        return null;
    }

    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1920, 1080), Color.White);
        Globals.SpriteBatch.Draw(traderTexture, backgroundRectangle, Color.White);
        buttonTrade.Draw();
        buttonLeaveTrader.Draw();


        traderMenu.Draw();
        _playerMenu.Draw();

        Globals.SpriteBatch.DrawString(Globals.Content.Load<SpriteFont>("Prospero"), message, new Vector2(800, 50), Color.Purple);
    }

    public override void Update(GameManager gm)
    {
        buttonTrade.Update();
        buttonLeaveTrader.Update();

        traderMenu.Update();
        _playerMenu.Update();
        buy2();
    }
}
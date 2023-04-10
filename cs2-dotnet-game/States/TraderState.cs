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

    public TraderState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("Misc/background2");
        GenerateRectangleBackground();
        traderTexture = Globals.Content.Load<Texture2D>("Trader/traderGuns");

        buttonTrade = new(Globals.Content.Load<Texture2D>("Trader/tradeButton"), new(100, 500));
        buttonTrade.OnClick += Buy;

        buttonLeaveTrader = new(Globals.Content.Load<Texture2D>("backButton"), new(100, 1000));
        buttonLeaveTrader.OnClick += gm.MenuState;

        traderMenu = new TraderMenu();
        _playerMenu = new PlayerMenu();


        //int inventoryWidth = screenWidth / 2 - 20;
        //int inventoryHeight = screenHeight - 40;
        //playerInventoryRectangle = new Rectangle(10, 10, inventoryWidth, inventoryHeight);
        //traderInventoryRectangle = new Rectangle(screenWidth / 2 + 10, 10, inventoryWidth, inventoryHeight);
        _gameManager = gm;

    }

    public async void Buy(object sender, EventArgs e)
    {
        if (traderMenu.selectedItem != null)
        {
            addItem(traderMenu.selectedItem);
            _gameManager.player.items.Add(traderMenu.selectedItem);
            _gameManager.Checked = false;
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
    }

    public override void Update(GameManager gm)
    {
        buttonTrade.Update();
        buttonLeaveTrader.Update();


        traderMenu.Update();
        _playerMenu.Update();
    }
}
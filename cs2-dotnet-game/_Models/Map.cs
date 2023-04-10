using _Models.Tiles;
using cs2_dotnet_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Point = Microsoft.Xna.Framework.Point;

namespace cs2_dotnet_game;

public class Map
{
    public readonly Point MAP_SIZE = new(50, 50);
    public readonly Point TILE_SIZE;
    public readonly Vector2 MAP_OFFSET = new(2f, 2);
    public readonly Tile[,] _tiles;
    //private Tile _lastMouseSelected;
    public (int x, int y) ScreenToMapPub(Vector2 pos) => ((int)pos.X / TILE_SIZE.X, (int)pos.Y / TILE_SIZE.Y);

    public Map()
    {
        _tiles = new Tile[MAP_SIZE.X, MAP_SIZE.Y];

        Texture2D[] textures =
        {
        Globals.Content.Load<Texture2D>("tile0"),
        Globals.Content.Load<Texture2D>("tileGrass"),
        Globals.Content.Load<Texture2D>("tileGrass"),
        Globals.Content.Load<Texture2D>("tile2"),
        Globals.Content.Load<Texture2D>("tile4"),
        Globals.Content.Load<Texture2D>("Enemy/tower1"), // Load EnemyTower texture
        Globals.Content.Load<Texture2D>("PlayerBase/PlayerBase"), // Load PlayerBase texture
        Globals.Content.Load<Texture2D>("Trader/traderBase"), // Load TraderBase texture
        Globals.Content.Load<Texture2D>("mountain"), // Load Mountain texture
        };

        TILE_SIZE.X = textures[0].Width;
        TILE_SIZE.Y = textures[0].Height / 2;

        Random random = new();

        // Add counts for different tiles
        int enemyTowerCount = 25;
        int playerBaseCount = 1;
        int traderBaseCount = 5;
        int mountainCount = 200;

        // Add method to generate the special tiles
        GenerateSpecialTiles(enemyTowerCount, playerBaseCount, traderBaseCount, mountainCount, textures);

        for (int y = 0; y < MAP_SIZE.Y; y++)
        {
            for (int x = 0; x < MAP_SIZE.X; x++)
            {
                if (_tiles[x, y] == null) // Check if a tile is already placed
                {
                    int r = random.Next(0, 4); // Only use the first 5 textures for regular tiles
                    _tiles[x, y] = new Tile(textures[r], MapToScreen(x, y));
                }
            }
        }
    }

    private void GenerateSpecialTiles(int enemyTowerCount, int playerBaseCount, int traderBaseCount, int mountainCount, Texture2D[] textures)
    {
        Random random = new();

        while (enemyTowerCount > 0 || playerBaseCount > 0 || traderBaseCount > 0 || mountainCount > 0)
        {
            int x = random.Next(0, MAP_SIZE.X - 1);
            int y = random.Next(0, MAP_SIZE.Y - 1);

            if (_tiles[x, y] == null) // Check if a tile is already placed
            {
                if (enemyTowerCount > 0)
                {
                    _tiles[x, y] = new EnemyTower(textures[5], MapToScreen(x, y));
                    enemyTowerCount--;
                }
                else if (playerBaseCount > 0)
                {
                    _tiles[x, y] = new PlayerBase(textures[6], MapToScreen(x, y));
                    playerBaseCount--;
                }
                else if (traderBaseCount > 0)
                {
                    _tiles[x, y] = new TraderBase(textures[7], MapToScreen(x, y));
                    traderBaseCount--;
                }
                else if (mountainCount > 0)
                {
                    _tiles[x, y] = new Mountain(textures[8], MapToScreen(x, y));
                    mountainCount--;
                }
            }
        }
    }

    public Vector2 MapToScreen(int mapX, int mapY)
    {
        var screenX = (mapX - mapY) * TILE_SIZE.X / 2 + MAP_OFFSET.X * TILE_SIZE.X;
        var screenY = (mapY + mapX) * TILE_SIZE.Y / 2 + MAP_OFFSET.Y * TILE_SIZE.Y;

        return new(screenX, screenY);
    }

    public Point ScreenToMap(Point mousePos)
    {
        Vector2 cursor = new(mousePos.X - (int)(MAP_OFFSET.X * TILE_SIZE.X), mousePos.Y - (int)(MAP_OFFSET.Y * TILE_SIZE.Y));

        var x = cursor.X + 2 * cursor.Y - TILE_SIZE.X / 2;
        int mapX = x < 0 ? -1 : (int)(x / TILE_SIZE.X);
        var y = -cursor.X + 2 * cursor.Y + TILE_SIZE.X / 2;
        int mapY = y < 0 ? -1 : (int)(y / TILE_SIZE.X);

        return new(mapX, mapY);
    }

    public Tile CheckSpecialTileReached(Hero hero)
    {
        Point heroMapPos = ScreenToMap(new Point((int)hero._position.X, (int)hero._position.Y));
        Tile specialTile = _tiles[heroMapPos.X, heroMapPos.Y];

        if (specialTile is EnemyTower || specialTile is PlayerBase || specialTile is TraderBase)
        {
            return specialTile;
        }

        return null;
    }

    public void Update()
    {
        for (int y = 0; y < MAP_SIZE.Y; y++)
        {
            for (int x = 0; x < MAP_SIZE.X; x++) _tiles[x, y].Update();
        }
    }

    public void Draw()
    {
        for (int y = 0; y < MAP_SIZE.Y; y++)
        {
            for (int x = 0; x < MAP_SIZE.X; x++)
            {
                _tiles[x, y].Draw();
            }
        }
    }
}

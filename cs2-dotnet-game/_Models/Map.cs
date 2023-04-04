using cs2_dotnet_game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Point = Microsoft.Xna.Framework.Point;

namespace _Models;

public class Map
{
    public readonly Point MAP_SIZE = new(30, 30);
    public readonly Point TILE_SIZE;
    public readonly Vector2 MAP_OFFSET = new(2f, 2);
    public readonly Tile[,] _tiles;
    private Tile _lastMouseSelected;
    public (int x, int y) ScreenToMapPub(Vector2 pos) => ((int)pos.X / TILE_SIZE.X, (int)pos.Y / TILE_SIZE.Y);

    public Map()
    {
        _tiles = new Tile[MAP_SIZE.X, MAP_SIZE.Y];

        Texture2D[] textures =
        {
            Globals.Content.Load<Texture2D>("tile0"),
            Globals.Content.Load<Texture2D>("tile1"),
            Globals.Content.Load<Texture2D>("tile2"),
            Globals.Content.Load<Texture2D>("tile3"),
            Globals.Content.Load<Texture2D>("tile4"),
        };

        TILE_SIZE.X = textures[0].Width;
        TILE_SIZE.Y = textures[0].Height / 2;

        Random random = new();

        for (int y = 0; y < MAP_SIZE.Y; y++)
        {
            for (int x = 0; x < MAP_SIZE.X; x++)
            {
                int r = random.Next(0, textures.Length);
                _tiles[x, y] = new(textures[r], MapToScreen(x, y), 10, 30);
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

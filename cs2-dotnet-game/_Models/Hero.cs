using _Managers;
using _Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using _Models.Sprites;
using System.Diagnostics;

namespace cs2_dotnet_game;

public class Hero : Sprite
{
    public Vector2 DestinationPosition { get; protected set; }
    public bool MoveDone { get; protected set; }
    protected float speed;
    public Texture2D _texture;
    public List<Vector2> Path { get; private set; }
    private int _current;
    public Vector2 _position;
    private Vector2 _minPos, _maxPos;

    public Hero(Texture2D texture, Vector2 pos) : base(texture, pos)
    {
        speed = 500;
        _texture = texture;
        _origin = new Vector2(-_texture.Width / 2, _texture.Height / 2);
        _position = Adjustposition(pos);
        DestinationPosition = _position;
        MoveDone = true;
    }

    public void SetBounds(Point mapSize, Point tileSize)
    {
        _minPos = new((-tileSize.X / 2) + _origin.X, (-tileSize.Y / 2) + _origin.Y);
        _maxPos = new(mapSize.X - (tileSize.X / 2) - _origin.X, mapSize.Y - (tileSize.X / 2) - _origin.Y);
    }

    public void SetPath(List<Vector2> path)
    {
        if (path is null) return;
        if (path.Count < 1) return;

        Path = path;
        _current = 0;
        DestinationPosition = Path[_current];
        MoveDone = false;
    }

    private Vector2 Adjustposition(Vector2 pos)
    {
        return new Vector2(pos.X - _texture.Width / 2, pos.Y - _texture.Height);
    }

    private bool NearDestination()
    {
        if ((DestinationPosition - _position).Length() < 5)
        {
            _position = DestinationPosition;

            if (_current < Path.Count - 1)
            {
                _current++;
                DestinationPosition = Path[_current];
            }
            else
            {
                MoveDone = true;
            }
            return true;
        }
        return false;
    }

    public override void Update()
    {
        if (MoveDone) return;

        var direction = DestinationPosition - _position;
        if (direction != Vector2.Zero) direction.Normalize();

        var distance = Globals.TotalSeconds * speed;
        int iterations = (int)Math.Ceiling(distance / 5);
        distance /= iterations;

        for (int i = 0; i < iterations; i++)
        {
            _position += direction * distance;
            if (NearDestination()) return;
        }
    }

    public override void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, _position, null, _color, 0f, _origin, 1f, SpriteEffects.None, 0f);
    }
}
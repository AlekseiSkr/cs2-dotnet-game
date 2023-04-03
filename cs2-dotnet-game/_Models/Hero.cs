using _Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace cs2_dotnet_game;

public class Hero : Sprite
{
    public Vector2 DestinationPosition { get; protected set; }
    public bool MoveDone { get; protected set; }
    protected float speed;
    public List<Vector2> Path { get; private set; }
    private int _current;

    public Hero(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        speed = 500;
        Origin = new Vector2(-Texture.Width / 2, Texture.Height / 2);
        Position = AdjustPosition(pos);
        DestinationPosition = Position;
        MoveDone = true;
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

    private Vector2 AdjustPosition(Vector2 pos)
    {
        return new Vector2(pos.X - Texture.Width / 2, pos.Y - Texture.Height);
    }

    private bool NearDestination()
    {
        if ((DestinationPosition - Position).Length() < 5)
        {
            Position = DestinationPosition;

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

    public void Update()
    {
        if (MoveDone) return;

        var direction = DestinationPosition - Position;
        if (direction != Vector2.Zero) direction.Normalize();

        var distance = Globals.TotalSeconds * speed;
        int iterations = (int)Math.Ceiling(distance / 5);
        distance /= iterations;

        for (int i = 0; i < iterations; i++)
        {
            Position += direction * distance;
            if (NearDestination()) return;
        }
    }
}
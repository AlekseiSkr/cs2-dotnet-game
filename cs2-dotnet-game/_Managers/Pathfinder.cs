
using _Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace cs2_dotnet_game;


public static class Pathfinder
{
    class Node
    {
        public int x;
        public int y;
        public Node parent;
        public bool visited;

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    private static Node[,] _nodeMap;
    private static Map _map;
    private static Hero _hero;
    private static readonly int[] row = { -1, 0, 0, 1 };
    private static readonly int[] col = { 0, -1, 1, 0 };

    public static void Init(Map map, Hero hero)
    {
        _map = map;
        _hero = hero;
    }

    public static bool Ready()
    {
        return _hero.MoveDone;
    }

    public static (int x, int y) ScreenToMap(Vector2 pos)
    {
        Point position = new Point(Convert.ToInt32(pos.X + _map.TILE_SIZE.X / 2), Convert.ToInt32(pos.Y + _map.TILE_SIZE.Y / 2));
        return (_map.ScreenToMap(position).X, _map.ScreenToMap(position).Y);
    }

    private static bool IsValid(int x, int y)
    {
        return x >= 0 && x < _nodeMap.GetLength(1) && y >= 0 && y < _nodeMap.GetLength(1);
    }

    private static void CreateNodeMap()
    {
        _nodeMap = new Node[_map.MAP_SIZE.X, _map.MAP_SIZE.Y];

        for (int i = 0; i < _map.MAP_SIZE.X; i++)
        {
            for (int j = 0; j < _map.MAP_SIZE.Y; j++)
            {
                _map._tiles[i, j].Path = false;
                _nodeMap[i, j] = new(i, j);
                if (_map._tiles[i, j].Blocked) _nodeMap[i, j].visited = true;
            }
        }
    }

    public static List<Vector2> BFSearch(int goalX, int goalY)
    {
        CreateNodeMap();
        Queue<Node> q = new();

        (int startX, int startY) = ScreenToMap(_hero._position);
        var start = _nodeMap[startX, startY];
        q.Enqueue(start);

        while (q.Count > 0)
        {
            Node curr = q.Dequeue();

            if (curr.x == goalX && curr.y == goalY)
            {
                return RetracePath(goalX, goalY);
            }

            // Mark the current node as visited
            curr.visited = true;

            for (int i = 0; i < row.Length; i++)
            {
                int newX = curr.x + row[i];
                int newY = curr.y + col[i];

                if (IsValid(newX, newY) && !_nodeMap[newX, newY].visited)
                {
                    q.Enqueue(_nodeMap[newX, newY]);
                    _nodeMap[newX, newY].visited = true;
                    _nodeMap[newX, newY].parent = curr;
                }
            }
        }

        return null;
    }


    private static List<Vector2> RetracePath(int goalX, int goalY)
    {
        Stack<Vector2> stack = new();
        List<Vector2> result = new();
        Node curr = _nodeMap[goalX, goalY];

        while (curr is not null)
        {
            _map._tiles[curr.x, curr.y].Path = true;
            stack.Push(_map.MapToScreen(curr.x, curr.y)); // Convert map coordinates to screen coordinates
            curr = curr.parent;
        }

        while (stack.Count > 0) result.Add(stack.Pop());

        _hero.SetPath(result);

        return result;
    }
}
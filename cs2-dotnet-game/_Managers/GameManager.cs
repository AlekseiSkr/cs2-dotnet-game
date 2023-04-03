using _Managers;
using _Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace cs2_dotnet_game;

public class GameManager
{
    private readonly Map _map;
    private readonly Hero _hero;
    //private readonly Camera _camera;

    public GameManager()
    {
        _map = new Map();
        Vector2 heroTilePosition = new Vector2(2, 3); // Set the desired tile position for the hero
        Vector2 heroScreenPosition = _map.MapToScreen((int)heroTilePosition.X, (int)heroTilePosition.Y);
        _hero = new Hero(Globals.Content.Load<Texture2D>("hero"), heroScreenPosition);
        Pathfinder.Init(_map, _hero);
        //_camera = new Camera();
    }

    private void OnLeftClick()
    {
        if (InputManager.MouseClicked)
        {
            var clickedPosition = InputManager.MouseClickedPosition;
            var (mapX, mapY) = _map.ScreenToMap(clickedPosition);
        }
    }

    private void OnRightClick()
    {
        if (InputManager.MouseRightClicked)
        {
            var clickedPosition = InputManager.RightClickedPosition;
            var (mapX, mapY) = _map.ScreenToMap(clickedPosition);

            if (mapX >= 0 && mapX < _map.MAP_SIZE.X && mapY >= 0 && mapY < _map.MAP_SIZE.Y)
            {
                var path = Pathfinder.BFSearch(mapX, mapY);
                _hero.SetPath(path);

                // Set the target position to the screen position of the clicked tile
                var targetPosition = _map.MapToScreen(mapX, mapY);
                _hero.DestinationPosition.Equals(targetPosition);
            }
        }
    }


    public void Update()
    {
        InputManager.Update();
        _map.Update();
        _hero.Update();
        OnRightClick();
        OnLeftClick();
       // _camera.Update(_hero.Position, Globals.WindowSize.X, Globals.WindowSize.Y); // Update the camera with the hero's position

    }


    public void Draw()
    {
        //Globals.SpriteBatch.Begin(transformMatrix: _camera.Transform);

        Globals.SpriteBatch.Begin();
        _map.Draw();
        _hero.Draw();

        Globals.SpriteBatch.End();
    }
}

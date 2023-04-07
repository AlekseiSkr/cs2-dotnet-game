using _Managers;
using _Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace cs2_dotnet_game;

public class PlayState : State
{

    private readonly Map _map;
    private readonly Hero _hero;
    private readonly Camera _camera;

    private readonly Texture2D backgroundTexture;
    private readonly Button buttonLeave;


    public PlayState(GameManager gm)
    {
        backgroundTexture = Globals.Content.Load<Texture2D>("playBackground");
        _map = new Map();
        Vector2 heroTilePosition = new Vector2(2, 3); // Set the start tile for the hero
        Vector2 heroScreenPosition = _map.MapToScreen((int)heroTilePosition.X, (int)heroTilePosition.Y);
        _hero = new Hero(Globals.Content.Load<Texture2D>("hero"), heroScreenPosition);
        _hero.SetBounds(_map.MAP_SIZE, _map.TILE_SIZE);
        Pathfinder.Init(_map, _hero);
        _camera = new Camera();

        buttonLeave = new(Globals.Content.Load<Texture2D>("backButton"), new(2, 3));
        buttonLeave.OnClick += gm.MenuState;
    }

    public static Vector2 PointToVector2(Point point)
    {
        return new Vector2(point.X, point.Y);
    }

    private void OnLeftClick()
    {
        if (true)
        {
            var clickedPosition = InputManager.MouseClickedPosition;
            var (mapX, mapY) = _map.ScreenToMap(clickedPosition);
        }
    }

    private void OnRightClick()
    {
        if (InputManager.MouseRightClicked)
        {
            Matrix inverseViewMatrix = Matrix.Invert(_camera.Transform);
            Vector2 worldPosition = Vector2.Transform(PointToVector2(InputManager.RightClickedPosition), inverseViewMatrix);
            var (mapX, mapY) = _map.ScreenToMap(new Point((int)worldPosition.X, (int)worldPosition.Y));

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


    public override void Update(GameManager gm)
    {
        
        InputManager.Update();
        _map.Update();
        _hero.Update();
        OnRightClick();
        OnLeftClick();
        _camera.Update(_hero._position, Globals.Bounds.X, Globals.Bounds.Y, _hero._texture);
        TransformationMatrix = _camera.Transform;
        buttonLeave.Update();
    }


    public override void Draw(GameManager gm)
    {
        Globals.SpriteBatch.Draw(backgroundTexture, new Rectangle(-3000, -1000, 10000, 5000), Color.White);
        buttonLeave.Draw();

        _map.Draw();
        _hero.Draw();
    }

}

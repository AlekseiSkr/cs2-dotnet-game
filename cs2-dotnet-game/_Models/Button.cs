using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;
public class Button : ButtonSprite
{
    protected Rectangle _rectangle;    
    public event EventHandler OnClick;
    public bool Disabled { get; set; }

    public Button(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        _rectangle = new((int)(pos.X - origin.X), (int)(pos.Y - origin.Y), tex.Width, tex.Height);
        
    }
    public void Update()
    {
        color = Color.White;
        if (_rectangle.Contains(InputManager.MouseRectangle))
        {
            color = Color.DarkGray;

            if (InputManager.MouseClicked)
            {
                OnClick?.Invoke(this, EventArgs.Empty);
            }
        }

        if (Disabled) color *= 0.3f;
    }
}

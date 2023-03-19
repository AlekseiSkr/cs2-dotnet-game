using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs2_dotnet_game;
public class Button : Sprite
{
    #region Fields
    private readonly Rectangle _rectangle;
    private SpriteFont _font;
    private Color _penColour;

    #endregion

    #region Properties
    public event EventHandler OnClick;
    public bool Disabled { get; set; }
    public String Text { get; set; }
    #endregion

    #region Methods
    public Button(Texture2D tex, Vector2 pos) : base(tex, pos)
    {
        _rectangle = new((int)(pos.X - origin.X), (int)(pos.Y - origin.Y), tex.Width, tex.Height);
        _font = Globals.Content.Load<SpriteFont>("Fonts/Font");
        _penColour = Color.Black;
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

    public override void Draw()
    {
        base.Draw();
        if (!string.IsNullOrEmpty(Text))
        {
            var x = (_rectangle.X + (_rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
            var y = (_rectangle.Y + (_rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);
            Globals.SpriteBatch.DrawString(_font, Text, new Vector2(x, y), _penColour);
        }
    }
    #endregion
}

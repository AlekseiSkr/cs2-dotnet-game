#region Using
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace cs2_dotnet_game;
#endregion
public class DialogBox
{
    #region Fields
    private readonly Texture2D _fillTexture;
    private readonly Texture2D _borderTexture;
    private List<string> _pages;
    private const float DialogBoxMargin = 24f;
    private Vector2 _characterSize = Globals.DialogFont.MeasureString(new StringBuilder("W", 1));
    private int MaxCharsPerLine => (int) Math.Floor((Size.X - DialogBoxMargin) / _characterSize.X);
    private int MaxLines => (int) Math.Floor((Size.Y - DialogBoxMargin) / _characterSize.Y) - 1;
    private int _currentPage;
    private int _interval;
    private Rectangle TextRectangle => new Rectangle(Position.ToPoint(), Size.ToPoint());
    private List<Rectangle> BorderRectangles => new List<Rectangle>
        {
            // Top (contains top-left & top-right corners)
            new Rectangle(TextRectangle.X - BorderWidth, TextRectangle.Y - BorderWidth,
                TextRectangle.Width + BorderWidth*2, BorderWidth),

            // Right
            new Rectangle(TextRectangle.X + TextRectangle.Size.X, TextRectangle.Y, BorderWidth, TextRectangle.Height),

            // Bottom (contains bottom-left & bottom-right corners)
            new Rectangle(TextRectangle.X - BorderWidth, TextRectangle.Y + TextRectangle.Size.Y,
                TextRectangle.Width + BorderWidth*2, BorderWidth),

            // Left
            new Rectangle(TextRectangle.X - BorderWidth, TextRectangle.Y, BorderWidth, TextRectangle.Height)
        };
    //private Vector2 TextPosition => new Vector2(Position.X + DialogBoxMargin / 2, Position.Y + DialogBoxMargin / 2);
    private Vector2 TextPosition => new Vector2(500, 840);

    private Stopwatch _stopwatch;
    #endregion
    #region Properties
    public string Text { get; set; }
    public bool Active { get; private set; }
    public Vector2 Position { get; set; }
    public Vector2 Size { get; set; }
    public Color FillColor { get; set; }
    public Color BorderColor { get; set; }
    public Color DialogColor { get; set; }
    public int BorderWidth { get; set; }
    #endregion

    #region Methods
    public DialogBox()
    {
        BorderWidth = 2;
        DialogColor = Color.Black;

        FillColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        BorderColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        _fillTexture = new Texture2D(Globals.Game.GraphicsDevice, 1, 1);
        _fillTexture.SetData(new[] { FillColor });

        _borderTexture = new Texture2D(Globals.Game.GraphicsDevice, 1, 1);
        _borderTexture.SetData(new[] { BorderColor });

        _pages = new List<string>();
        _currentPage = 0;

        var sizeX = (int)(Globals.Game.GraphicsDevice.Viewport.Width * 0.5);
        var sizeY = (int)(Globals.Game.GraphicsDevice.Viewport.Height * 0.2);

        Size = new Vector2(sizeX, sizeY);

        var posX = Globals.CenterScreen.X - (Size.X / 2f);
        var posY = Globals.Game.GraphicsDevice.Viewport.Height - Size.Y - 30;

        Position = new Vector2(posX, posY);
    }

    public void Initialize(string text = null)
    {
        Text = text ?? Text;

        _currentPage = 0;

        Show();
    }
    public void Show()
    {
        Active = true;

        // use stopwatch to manage blinking indicator
        _stopwatch = new Stopwatch();

        _stopwatch.Start();

        _pages = WordWrap(Text);
    }

    public void Hide()
    {
        Active = false;

        _stopwatch.Stop();

        _stopwatch = null;
    }
    public void Update()
    {
        if (Active)
        {
            // Button press will proceed to the next page of the dialog box
            //  && Program.Game.PreviousKeyState.IsKeyUp(Keys.Enter)
            if (InputManager.KeyState.IsKeyDown(Keys.Enter) && InputManager.LastKeyboardState.IsKeyUp(Keys.Enter))
            {
                if (_currentPage >= _pages.Count - 1)
                {
                    Hide();
                }
                else
                {
                    _currentPage++;
                    _stopwatch.Restart();
                }
            }

            if (InputManager.KeyState.IsKeyDown(Keys.P) && InputManager.LastKeyboardState.IsKeyUp(Keys.P))
            {
                if (_currentPage > 0)
                {
                    _currentPage--;
                    _stopwatch.Restart();
                }
            }

            // Shortcut button to skip entire dialog box
            //  && Program.Game.PreviousKeyState.IsKeyUp(Keys.X)
            if (InputManager.KeyState.IsKeyDown(Keys.X))
            {
                Hide();
            }
        }
    }

    public void Draw()
    {
        if (Active)
        {
            // top
            Globals.SpriteBatch.Draw(_borderTexture, new Vector2(480, 828), BorderRectangles[0], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            // right
            Globals.SpriteBatch.Draw(_borderTexture, new Vector2(1440, 828), BorderRectangles[1], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            // bottom
            Globals.SpriteBatch.Draw(_borderTexture, new Vector2(478, 1046), BorderRectangles[2], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            // left
            Globals.SpriteBatch.Draw(_borderTexture, new Vector2(478, 828), BorderRectangles[3], Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);


            // Draw background fill texture (in this example, it's 50% transparent white)
            Globals.SpriteBatch.Draw(_fillTexture, new Vector2(480, 830), TextRectangle, Color.Gray, 0, Vector2.Zero, 1f, SpriteEffects.None, 1f);


            // Draw the current page onto the dialog box
            Globals.SpriteBatch.DrawString(Globals.DialogFont, _pages[_currentPage], TextPosition, DialogColor);

            // Draw a blinking indicator to guide the player through to the next page
            // This stops blinking on the last page
            // NOTE: You probably want to use an image here instead of a string
            if (BlinkIndicator() || _currentPage == _pages.Count - 1)
            {
                /*var indicatorPosition = new Vector2(TextRectangle.X + TextRectangle.Width - (_characterSize.X) - 4,
                    TextRectangle.Y + TextRectangle.Height - (_characterSize.Y));*/

                Globals.SpriteBatch.DrawString(Globals.DialogFont, ">", new Vector2(1400, 1000), Color.Red);
            }
        }
    }

    private bool BlinkIndicator()
    {
        _interval = (int)Math.Floor((double)(_stopwatch.ElapsedMilliseconds % 1000));

        return _interval < 500;
    }
    private List<string> WordWrap(string text)
    {
        var pages = new List<string>();

        var capacity = MaxCharsPerLine * MaxLines > text.Length ? text.Length : MaxCharsPerLine * MaxLines;

        var result = new StringBuilder(capacity);
        var resultLines = 0;

        var currentWord = new StringBuilder();
        var currentLine = new StringBuilder();

        for (var i = 0; i < text.Length; i++)
        {
            var currentChar = text[i];
            var isNewLine = text[i] == '\n';
            var isLastChar = i == text.Length - 1;

            currentWord.Append(currentChar);

            if (char.IsWhiteSpace(currentChar) || isLastChar)
            {
                var potentialLength = currentLine.Length + currentWord.Length;

                if (potentialLength > MaxCharsPerLine)
                {
                    result.AppendLine(currentLine.ToString());

                    currentLine.Clear();

                    resultLines++;
                }

                currentLine.Append(currentWord);

                currentWord.Clear();

                if (isLastChar || isNewLine)
                {
                    result.AppendLine(currentLine.ToString());
                }

                if (resultLines > MaxLines || isLastChar || isNewLine)
                {
                    pages.Add(result.ToString());

                    result.Clear();

                    resultLines = 0;

                    if (isNewLine)
                    {
                        currentLine.Clear();
                    }
                }
            }
        }

        return pages;
    }
    #endregion    
}
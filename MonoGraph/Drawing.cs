using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGraph
{
    public static class Drawing
    {
        public const int Grid = 1;
        public const int GridWidth = 512;
        public const int GridHeight = 512;
        public const int Width = Grid * GridWidth;
        public const int Height = Grid * GridHeight;

        private static Texture2D blankTexture;

        private static SpriteFont arialFont;

        public static void InitializeGraphics(Game1 game)
        {
            // Initialize screen size
            game.Graphics.PreferredBackBufferWidth = Width;
            game.Graphics.PreferredBackBufferHeight = Height;
            game.Graphics.ApplyChanges();

            // Initialize blank texture
            blankTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            blankTexture.SetData(new[] { Color.White });

            // Load content
            arialFont = game.Content.Load<SpriteFont>("Arial");
        }

        // Draws given rect of given color
        public static void DrawRect(Rectangle rect, Color color, Game1 game)
        {
            game.SpriteBatch.Draw(blankTexture, rect, null, color);
        }

        // Draws given text at given position with given color
        public static void DrawText(string text, Vector2 position, Color color, Game1 game)
        {
            game.SpriteBatch.DrawString(arialFont, text, position, color);
        }
    }
}

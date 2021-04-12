using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGraph
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }

        private readonly Graph Graph = new Graph();

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initialize graphics
            Drawing.InitializeGraphics(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            // If escape key pressed, exit game
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            SpriteBatch.Begin(); // Begin sprite batch
            Graph.Draw(this); // Draw graph
            SpriteBatch.End(); // End sprite batch

            base.Draw(gameTime);
        }
    }
}

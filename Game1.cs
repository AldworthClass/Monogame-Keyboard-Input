using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Keyboard_Input
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState;

        Texture2D pacUpTexture;
        Texture2D pacDownTexture;
        Texture2D pacLeftTexture;
        Texture2D pacRightTexture;
        Texture2D pacSleepTexture;
        Texture2D pacTexture; // This stores the player texture to be used in the Draw() method

        Rectangle pacLocation;

                
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pacLocation = new Rectangle(10, 10, 75, 75);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            pacDownTexture = Content.Load<Texture2D>("PacDown");
            pacUpTexture = Content.Load<Texture2D>("PacUp");
            pacLeftTexture = Content.Load<Texture2D>("PacLeft");
            pacRightTexture = Content.Load<Texture2D>("PacRight");
            pacSleepTexture = Content.Load<Texture2D>("PacSleep");
            pacTexture = pacSleepTexture;
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                pacTexture = pacUpTexture;
                pacLocation.Y -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                pacTexture = pacDownTexture;
                pacLocation.Y += 2;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                pacTexture = pacLeftTexture;
                pacLocation.X -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                pacTexture = pacRightTexture;
                pacLocation.X += 2;
            }
            // If pacman is not moving make him sleep
            if (!keyboardState.IsKeyDown(Keys.Up) && !keyboardState.IsKeyDown(Keys.Right) && !keyboardState.IsKeyDown(Keys.Left) && !keyboardState.IsKeyDown(Keys.Down))
            {
                pacTexture = pacSleepTexture;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // Draw Pacman
           
            _spriteBatch.Draw(pacTexture, pacLocation, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

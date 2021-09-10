using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Keyboard_Input
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D pacUpTexture;
        Texture2D pacDownTexture;
        Texture2D pacLeftTexture;
        Texture2D pacRightTexture;
        Texture2D pacSleepTexture;

        Rectangle pacLocation;

        Direction pacDirection;

        enum Direction
        {
            up,
            down,
            left,
            right,
            sleep
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pacLocation = new Rectangle(10, 10, 30, 30);
            pacDirection = Direction.sleep;

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
            pacRightTexture = Content.Load<Texture2D>("PacSleep");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // Draw Pacman
            if (pacDirection == Direction.sleep)
                _spriteBatch.Draw(pacSleepTexture, pacLocation, Color.White);
            else if(pacDirection == Direction.left)
                _spriteBatch.Draw(pacLeftTexture, pacLocation, Color.White);
            else if (pacDirection == Direction.right)
                _spriteBatch.Draw(pacRightTexture, pacLocation, Color.White);
            else if (pacDirection == Direction.up)
                _spriteBatch.Draw(pacUpTexture, pacLocation, Color.White);
            else
                _spriteBatch.Draw(pacDownTexture, pacLocation, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

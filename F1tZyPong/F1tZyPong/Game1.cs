using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace F1tZyPong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        PaddleLeft LeftPaddle = new PaddleLeft();
        PaddleRight RightPaddle = new PaddleRight();
        Ball BallInPaly = new Ball();

        public Game1()
        {
            GameState.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            GameState.spriteBatch = new SpriteBatch(GraphicsDevice);

            LeftPaddle.LoadContent(Content.Load<Texture2D>("image\\paddleBlu"));
            RightPaddle.LoadContent(Content.Load<Texture2D>("image\\paddleRed"));
            BallInPaly.LoadContent(Content.Load<Texture2D>("image\\ballGrey"));

            // load the font
            GameState.GUIFont = Content.Load<SpriteFont>("GUIFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState KeyState = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || KeyState.IsKeyDown(Keys.Escape) == true)
                this.Exit();

            LeftPaddle.Update(gameTime);
            RightPaddle.Update(gameTime);

            CollisonDetection.CollisionDetection(BallInPaly, LeftPaddle, RightPaddle);

            BallInPaly.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GameState.spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);

            LeftPaddle.Draw(gameTime);
            RightPaddle.Draw(gameTime);
            BallInPaly.Draw(gameTime);

            GameState.DrawScore(gameTime);

            base.Draw(gameTime);

            GameState.spriteBatch.End();
        }
    }
}

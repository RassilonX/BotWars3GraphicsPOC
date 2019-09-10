using BotWars3.Graphics.ObjectModels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BotWars3.Graphics
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GraphicsMain : Game
    {
        //ball properties - Extract to list of ball class
        //Texture2D ballTexture;
        //Vector2 ballPosition;
        //float ballSpeed;

        List<Ball> ballsList;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public GraphicsMain()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = GlobalVariables.screenWidth,
                PreferredBackBufferHeight = GlobalVariables.screenHeight
            };
            Content.RootDirectory = "Content";

            //This is currently standing in for our assets, so this is where we point to lists
            ballsList = new List<Ball>()
            {
                new Ball()
            };
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Load ball list with each one having the same textures
            //This is ideal for each of our assets in the game
            foreach(var item in ballsList)
            {
                item.ballTexture = Content.Load<Texture2D>("ball");
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //// TODO: Add your update logic here
            foreach(var item in ballsList)
            {
                item.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //draw the balls
            foreach (var item in ballsList)
            {
                spriteBatch.Draw(
                    item.ballTexture, //texture
                    item.ballPosition, //position
                    null, //rectangle?
                    Color.White, //base colour
                    0f, //rotation
                    new Vector2(item.ballTexture.Width / 2, item.ballTexture.Height / 2), //origin
                    Vector2.One, //scale
                    SpriteEffects.None,//effects
                    0f //layer depth
                );
            }


            spriteBatch.End();

            //This has to be at the bottom of the function
            base.Draw(gameTime);
        }
    }
}

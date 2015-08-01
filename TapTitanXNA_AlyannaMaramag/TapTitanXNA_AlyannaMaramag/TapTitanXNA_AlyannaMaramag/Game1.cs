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

namespace TapTitanXNA_AlyannaMaramag
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Properties
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ContentManager content;
        Level level;
        #endregion
//        Texture2D monster;
//        Texture2D ally;
//        Vector2 monsterPosition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            this.content = Content;

            level = new Level(content);

            graphics.PreferredBackBufferWidth = Level.windowWidth;
            graphics.PreferredBackBufferHeight = Level.windowHeight;
            
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;

            this.content = Content;

            this.IsMouseVisible = true;
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

            level.LoadContent();
            //monster = content.Load<Texture2D>("Monster/Monster01");
            //ally = content.Load<Texture2D>("Ally/Alllll");


            //int mPositionX = (windowWidth / 2) - (monster.Width / 2);
            //int mPositionY = (windowHeight / 3) - (monster.Height / 2);
            //monsterPosition = new Vector2((float)mPositionX, (float)mPositionY);

            
            // TODO: use this.Content to load your game content here
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
            // Allows the game to exit

            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            level.Update(gameTime);



            // TODO: Add your update logic here

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
            level.Draw(gameTime, spriteBatch);
            /*
            //spriteBatch.Draw(monster, Vector2.Zero, Color.White);
            spriteBatch.Draw(monster,
            monsterPosition,
            null,
            Color.White,
            0.0f,
            Vector2.Zero,
            1.0f,
            SpriteEffects.None,
            0.0f);
            spriteBatch.Draw(ally, playerPosition, Color.White);
            */
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}

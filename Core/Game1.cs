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
using NeverEnding.Config;
using NeverEnding.GameObjects;
using NeverEnding.World;

namespace NeverEnding.Core
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RandomDebugSpriteManager rndSpriteMnger;
        ForcibleObject f1;
        ForcibleObject f2;
        CollisionControl CC;
        Floor floor;
      
#if DEBUG
        private DebugConsole debugConsole;
#endif
        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            rndSpriteMnger = new RandomDebugSpriteManager();
            CC = new CollisionControl();
            floor = new Floor();
            f1 = new ForcibleObject();
            //f2 = new ForcibleObject();
#if DEBUG
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 600;
#else
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
#endif

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
            floor.Initialize();
            rndSpriteMnger.Initialize(10);
            //HERE
            f1.Initialize(new Vector2(1,9), new Rectangle(0,0,GameConfig.TileWidth, GameConfig.TileHeight), "realAsset", 0.0f, null);
            //f2.Initialize(new Vector2(10, 50), new Vector2(GameConfig.TileWidth, GameConfig.TileHeight), "realAsset", 0.0f);
#if DEBUG
            int floorDebugvalue = GameConfig.XWidth/GameConfig.TileWidth;
            debugConsole = new DebugConsole(floorDebugvalue,true,true);
#endif
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
        //HERE
            floor.LoadContent(this.Content);
            rndSpriteMnger.LoadContent(this.Content);
            f1.LoadContent(this.Content);
            //f2.LoadContent(this.Content);
#if DEBUG
            debugConsole.LoadContent(this.Content);
#endif
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
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
           
            //HERE
            floor.Update(gameTime);
            CC.Update(gameTime);
            rndSpriteMnger.Update(gameTime);
            f1.Update(gameTime, new Vector2(1, 1), Direction.South);
            //f2.Update(gameTime, new Vector2(1, 1), Direction.None);
#if DEBUG
            debugConsole.Update(gameTime);
#endif
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            spriteBatch.Begin();
           //HERE
            floor.Draw(spriteBatch);
            rndSpriteMnger.Draw(spriteBatch);
            f1.Draw(spriteBatch);
            //f2.Draw(spriteBatch);
#if DEBUG
            debugConsole.Draw(spriteBatch);
#endif
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

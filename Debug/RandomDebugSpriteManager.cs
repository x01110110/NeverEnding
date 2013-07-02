using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NeverEnding.GameObjects;
using NeverEnding.Config;

namespace NeverEnding
{
    class RandomDebugSpriteManager
    {
        private Dictionary<ForcibleObject, Direction> sprites = new Dictionary<ForcibleObject, Direction>();
        private Random random = new Random();

        public void Initialize(int count)
        {
            var pos = 0;
            while (pos < count)
            {
                var temp = new ForcibleObject();
                temp.Initialize(new Vector2(random.Next(GameConfig.XWidth - GameConfig.TileWidth), random.Next(GameConfig.YHeight - GameConfig.TileHeight)), new Rectangle(0, 0, GameConfig.TileWidth, GameConfig.TileHeight), "realAsset", 0.0f, null);
                var direction = (Direction)random.Next(0, 5);
                sprites.Add(temp, direction);
                pos++;
            }
           
        }

        public void LoadContent(ContentManager contentManager)
        {
            foreach (var sprite in sprites)
            {
                sprite.Key.LoadContent(contentManager);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var sprite in sprites)
            {
                sprite.Key.Update(gameTime, new Vector2(1, 1), sprite.Value);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var sprite in sprites)
            {
                sprite.Key.Draw(spriteBatch);
            }
        }
    }
}

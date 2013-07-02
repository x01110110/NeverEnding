using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NeverEnding.Config;
using NeverEnding.GameObjects;

namespace NeverEnding.World
{
    class Floor
    {
        List<AnimatedFloorObject> list = new List<AnimatedFloorObject>();

        public void Initialize()
        {
            var xPos = 0;
            var yPos = 0;
            while (xPos < GameConfig.XWidth)
            {
                while (yPos < GameConfig.YHeight)
                {
                    var temp = new AnimatedFloorObject();
                    temp.Initialize(new Vector2(xPos, yPos), new Rectangle(0,0,GameConfig.TileWidth, GameConfig.TileHeight), "Gravel", 0.0f, new List<string>());
                    list.Add(temp);
                    yPos = yPos + GameConfig.TileHeight;
                }
                yPos = 0;
                xPos = xPos + GameConfig.TileWidth;
            }
        }

        public void LoadContent(ContentManager contentManager)
        {
            foreach (var animatedFloorObject in list)
            {
                animatedFloorObject.LoadContent(contentManager);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var animatedFloorObject in list)
            {
                animatedFloorObject.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var animatedFloorObject in list)
            {
                animatedFloorObject.Draw(spriteBatch);
            }
        }

    }
}

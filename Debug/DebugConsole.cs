using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NeverEnding.GameObjects;
using NeverEnding.Model;

namespace NeverEnding
{
    class DebugConsole
    {
        public List<AnimatedFloorObject> gameObjects;
        public SpriteFont font;

        private int Limit;

        //info for gameObjects
        public Boolean showObjectInfo;
        private Vector2 coordStartingPosition = new Vector2(800, 0);
        private Dictionary<GameObject, DebugInfoModel> debugCoordDictionary;

        //FPS
        public Boolean showFPS;
        int total_frames = 0;
        float elapsed_time = 0.0f;
        int fps = 0;

        public DebugConsole(int limit, Boolean showObjectInfo, Boolean showFPS)
        {
            this.showObjectInfo = showObjectInfo;
            this.showFPS = showFPS;
            this.Limit = limit;

            if(showObjectInfo)
                debugCoordDictionary = new Dictionary<GameObject, DebugInfoModel>();
                
        }

        public void LoadContent(ContentManager contentManager)
        {
            font = contentManager.Load<SpriteFont>("MyFont");
        }

        public void Update(GameTime gameTime)
        {
            gameObjects = GameObjectManager.GetAllAnimatedFloorO();
            var count = 0;
            if(showObjectInfo)
            {
                
                    var displayPosition = coordStartingPosition;
                    foreach (var gameObject in gameObjects)
                    {
                        if (count > this.Limit)
                            break;

                        if (!debugCoordDictionary.ContainsKey(gameObject))
                            debugCoordDictionary.Add(gameObject, new DebugInfoModel(displayPosition, gameObject));
                        else
                            debugCoordDictionary[gameObject].Update();
                    

                        displayPosition = displayPosition + new Vector2(0, 11);
                        count++;
                    }
                    
                
            }

            if(showFPS)
            {
                elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsed_time >= 1000.0f)
                {
                    fps = total_frames;
                    total_frames = 0;
                    elapsed_time = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(showObjectInfo)
            {
                foreach (var coordModel in debugCoordDictionary.Values)
                {
                    spriteBatch.DrawString(font, coordModel.displayString, coordModel.displayPosition, Color.Red);
                }
                
            }
            if(showFPS)
            {
                total_frames++;
                spriteBatch.DrawString(font, string.Format("FPS={0}", fps), new Vector2(0, 0), Color.Red);
            }
        }

    }
}

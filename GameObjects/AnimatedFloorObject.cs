using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NeverEnding.Config;

namespace NeverEnding.GameObjects
{
    class AnimatedFloorObject : FloorObject
    {
        public Rectangle HitBox;
        public Boolean IsSteppedOn;
        public Boolean fürDraw;

        
        public new void Initialize(Vector2 position, Rectangle sector, String assetName, float rotation, List<String> animations) //could be some kind of animation class later on
        {
            base.Initialize(position, sector, assetName, rotation);
            this.HitBox = new Rectangle((int)position.X, (int)position.Y, GameConfig.TileWidth, GameConfig.TileHeight);
            GameObjectManager.AddAFO(this);
        }

        public new void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
        }

        public new void Update(GameTime gameTime)
        {
            if(IsSteppedOn)
            {
                fürDraw = true;
                //first animation
                //second animation
                //third animation
                //animation
            }
            else
            {
                fürDraw = false;
                //back to default
            }
            IsSteppedOn = false;
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
#if DEBUG
            if(!fürDraw)
            {
                spriteBatch.Draw(this.Texture, this.Position, this.Sector, Color.White, 0.0f, Vector2.Zero, GameConfig.Scale, SpriteEffects.None, 0);
            }
            else
            {
                spriteBatch.Draw(this.DebugTexture, this.Position, this.Sector, Color.White, 0.0f, Vector2.Zero, GameConfig.Scale, SpriteEffects.None, 0);
            }
            //base.Draw(spriteBatch);
#else
            spriteBatch.Draw(this.Texture, this.Position, this.Sector, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
#endif
      
        }
        
        /*
        public Boolean SteppedOn()
        {
            var allForcible = GameObjectManager.GetAllForcibleGO();
            
            foreach (var forcibleObject in allForcible)
            {
                if ((forcibleObject.HitBox.Intersects(this.Sector)))
                    return true;
            }

            return false;
        }
         * */
    }
}

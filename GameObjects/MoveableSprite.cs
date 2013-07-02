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
    class MoveableSprite : MoveAbleObject
    {
        public String AssetName;
        public float Rotation;
        public Texture2D Texture;
        
        public new void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);

            this.Texture = contentManager.Load<Texture2D>(this.AssetName);
        }

        public void Initialize(Vector2 position, Rectangle sector, String assetName, float rotation)
        {
            base.Initialize(position, sector);
            this.AssetName = assetName;
            this.Rotation = rotation;
        }
        
        public new void Update(GameTime gameTime, Vector2 speed, Direction direction)
        {
            base.Update(gameTime, speed, direction);
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
#if DEBUG
            base.Draw(spriteBatch);
#else
            spriteBatch.Draw(this.Texture, this.Position, this.Sector, Color.White, 0.0f, Vector2.Zero,  GameConfig.Scale, SpriteEffects.None, 0);
#endif
        }
    }
}

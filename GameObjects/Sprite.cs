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
    public class Sprite : GameObject
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
            Initialize(position,sector);
            this.AssetName = assetName;
            this.Rotation = rotation;
        }

        public new void Update()
        {
            
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Position, this.Sector, Color.White, 0.0f, Vector2.Zero, GameConfig.Scale, SpriteEffects.None, 0);
        }
      
    }
}

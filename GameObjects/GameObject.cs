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
    public class GameObject
    {
        public Int64 Id;
        public Vector2 Position;
        public Rectangle Sector;
        public Texture2D DebugTexture;
        public String Name;
        //TÄÄÄST
        public SpriteFont font;


        public GameObject()
        {
            this.Id = GameObjectManager.getGOSequence();
            this.Name = this.GetType().ToString() + this.Id;
            GameObjectManager.AddGO(this);
        }

        public void Initialize(Vector2 position, Rectangle sector)
        {
            this.Position = position;
            this.Sector = sector;
        }

        public void LoadContent(ContentManager contentManager)
        {
            this.DebugTexture = contentManager.Load<Texture2D>("Debug");

            //TÄÄÄÄÄÄÄÄST!!!
            font = contentManager.Load<SpriteFont>("MyFont");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.DebugTexture, this.Position, this.Sector, Color.White, 0.0f, Vector2.Zero, GameConfig.Scale, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, this.Id.ToString(), this.Position, Color.Red);
        }
    } 
}

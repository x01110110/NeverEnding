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
    class ForcibleObject : MoveableSprite
    {
        public Rectangle HitBox;
        //TEST ! RENAME !
        public Boolean IsHit;

        public ForcibleObject()
        {
            GameObjectManager.AddFGO(this);
        }

        public new void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
        }

        public new void Update(GameTime gameTime, Vector2 speed, Direction direction)
        {
            //HIT LOGIC
            //if (this.Collides(direction, speed))
            //    this.IsHit = true; 
            

            if(!this.IsHit)
            {
                base.Update(gameTime, speed, direction);
                this.ChangeHitbox(speed, direction);
            }

            this.IsHit = false;

        }

        public void Initialize(Vector2 position, Rectangle sector, String assetName, float rotation, Vector2? hitBox)
        {
            base.Initialize(position, sector, assetName, rotation);
            if(hitBox == null)
            {
                this.HitBox = new Rectangle((int)position.X, (int)position.Y, GameConfig.TileWidth, GameConfig.TileHeight);
            }
            else
            {
                var temp = (Vector2) hitBox;
                this.HitBox = new Rectangle((int)position.X, (int)position.Y, (int)temp.X, (int)temp.Y);
            }
            
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        
        //CUSTOM
        public Rectangle ChangeHitbox(Vector2 speed, Direction direction)
        {
            this.HitBox = CalcNewHitbox(this.HitBox, speed, direction);
            return this.HitBox;
        }

        public static Rectangle CalcNewHitbox(Rectangle hitBox, Vector2 speed, Direction direction)
        {
            var newPosition = MoveAbleObject.CalcNewPosition(new Vector2(hitBox.X, hitBox.Y), speed, direction);
            hitBox.X = (int) newPosition.X;
            hitBox.Y = (int) newPosition.Y;
            return hitBox;
        }
        /*
        public Boolean Collides(Direction direction, Vector2 speed)
        {
            var allForcible = GameObjectManager.GetAllForcibleGO();
            var estimatedHitbox = CalcNewHitbox(this.HitBox,speed, direction);

            //TEST
            if (this.HitBox.Intersects(GameConfig.NorthWall))
                return true;
            if (this.HitBox.Intersects(GameConfig.EastWall))
                return true;
            if (this.HitBox.Intersects(GameConfig.SouthWall))
                return true;
            if (this.HitBox.Intersects(GameConfig.WestWall))
                return true;



            foreach (var forcibleObject in allForcible)
            {
                if(forcibleObject == this)
                    continue;
                
                if ((forcibleObject.HitBox.Intersects(estimatedHitbox)))
                    return true;

            }

            return false;
        }
        */
    }
}

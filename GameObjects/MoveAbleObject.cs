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
    class MoveAbleObject : GameObject
    {
        public Vector2 CurrentSpeed;
        public Direction CurrentDirection;


        public new void LoadContent(ContentManager contentManager)
        {
            base.LoadContent(contentManager);
        }

        public void Update(GameTime gameTime, Vector2 speed, Direction direction)
        {
            CurrentSpeed = speed;
            CurrentDirection = direction;
            this.ChangePosition(speed, direction);
        }

        public new void Initialize(Vector2 position, Rectangle sector)
        {
            base.Initialize(position, sector);
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
#if DEBUG
            base.Draw(spriteBatch);
#endif
        }

        //CUSTOM
        public Vector2 ChangePosition(Vector2 speed, Direction direction)
        {
            this.Position = CalcNewPosition(this.Position, speed, direction);
            return this.Position;
        }

        public static Vector2 CalcNewPosition(Vector2 position, Vector2 speed, Direction direction)
        {
            return position += speed * Helper.ParseDirection(direction);
        }
    }
}

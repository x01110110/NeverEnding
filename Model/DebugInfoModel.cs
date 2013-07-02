using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using NeverEnding.GameObjects;

namespace NeverEnding.Model
{
    class DebugInfoModel
    {
        public GameObject gameObject;
        public Vector2 displayPosition;
        public String displayString;

        public DebugInfoModel(Vector2 displayPosition, GameObject gameObject)
        {
            this.displayPosition = displayPosition;
            this.gameObject = gameObject;

            this.CreateDisplayString();
        }

        public void Update()
        {
            this.CreateDisplayString();
        }

        public void CreateDisplayString()
        {
            displayString = gameObject.Name;
            if (gameObject is MoveableSprite)
            {
                var sb = new StringBuilder();
                var moveableSprite = (MoveableSprite) gameObject;
                sb.Append(moveableSprite.AssetName);
                sb.Append(moveableSprite.Id);
                sb.Append(" - ");
                sb.Append(moveableSprite.Position.X);
                sb.Append("x");
                sb.Append(moveableSprite.Position.Y);
                displayString = sb.ToString();
            }

            if (gameObject is ForcibleObject)
            {
                var sb = new StringBuilder();
                var forcibleObject = (ForcibleObject)gameObject;
                sb.Append(forcibleObject.AssetName);
                sb.Append(forcibleObject.Id);
                sb.Append(" - ");
                sb.Append(forcibleObject.Position.X);
                sb.Append("x");
                sb.Append(forcibleObject.Position.Y);
                sb.Append(" - ");
                sb.Append(forcibleObject.HitBox.X);
                sb.Append("x");
                sb.Append(forcibleObject.HitBox.Y);
                sb.Append(" - ");
                sb.Append(forcibleObject.IsHit);

                displayString = sb.ToString();
            }

            if(gameObject is AnimatedFloorObject)
            {
                var sb = new StringBuilder();
                var animatedFloorObject = (AnimatedFloorObject) gameObject;
                sb.Append(animatedFloorObject.AssetName);
                sb.Append(animatedFloorObject.Id);
                sb.Append(" - ");
                sb.Append(animatedFloorObject.Position.X);
                sb.Append("x");
                sb.Append(animatedFloorObject.Position.Y);
                sb.Append(" - ");
                sb.Append(animatedFloorObject.IsSteppedOn);

                displayString = sb.ToString();
            }
        }
    }
}

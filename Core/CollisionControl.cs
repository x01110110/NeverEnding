using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NeverEnding.Config;
using NeverEnding.GameObjects;

namespace NeverEnding.Core
{
    class CollisionControl
    {
       
        public void Initialize()
        {
           //ForcibleObjectCC.Initialize();
        }

        public void Update(GameTime gameTime)
        {
            var allForcibleGO = GameObjectManager.GetAllForcibleGO();
            var allAnimatedFloorO = GameObjectManager.GetAllAnimatedFloorO();

            foreach (var forcibleObject in allForcibleGO)
            {
                var estimatedHitbox = ForcibleObject.CalcNewHitbox(forcibleObject.HitBox, forcibleObject.CurrentSpeed, forcibleObject.CurrentDirection);
                
                //forcible - wall
                if (estimatedHitbox.Intersects(GameConfig.NorthWall))
                    forcibleObject.IsHit = true;
                if (estimatedHitbox.Intersects(GameConfig.EastWall))
                    forcibleObject.IsHit = true;
                if (estimatedHitbox.Intersects(GameConfig.SouthWall))
                    forcibleObject.IsHit = true;
                if (estimatedHitbox.Intersects(GameConfig.WestWall))
                    forcibleObject.IsHit = true;


                //forcible -> forcible
                foreach (var innerForcibleObject in allForcibleGO)
                {
                    if (forcibleObject == innerForcibleObject)
                        continue;

                    if (estimatedHitbox.Intersects(innerForcibleObject.HitBox))
                        forcibleObject.IsHit = true;
                }

                /*
                foreach (var animatedFloorObject in allAnimatedFloorO)
                {
                    if (estimatedHitbox.Intersects(animatedFloorObject.HitBox))
                        animatedFloorObject.IsSteppedOn = true;
                }
                */
                //SPÄTER MAL BENUTZEN, FEHLT NOCH RADIUS UM DAS OBJEKT DAMIT MAN IS STEPPED ON WIEDER ZURÜCKSETZEN KANN
                //forcible -> floor
                // x = 78
                // y = 200
                // 78 / 32 = 2,4 = 2 = 64
                // 200 / 32 = 6,25 = 6 = 192
                
                int tileX = estimatedHitbox.X / GameConfig.TileWidth;
                int tileY = estimatedHitbox.Y / GameConfig.TileHeight;
                // GET FLOOR!!! not animated floor! could be anything!
                var tile = GameObjectManager.GetAnimatedFloorO(new Vector2(tileX * GameConfig.TileWidth, tileY * GameConfig.TileHeight));
                
                var tileRectangle = new Rectangle((int)tile.Position.X, (int)tile.Position.Y, GameConfig.TileWidth, GameConfig.TileHeight);
                if(estimatedHitbox.Intersects(tileRectangle))
                {
                    tile.IsSteppedOn = true;
                }
                 
                //if (estimatedHitbox.Intersects(animatedFloorObject.Sector))
                //       animatedFloorObject.IsSteppedOn = true;




            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using NeverEnding.GameObjects;

namespace NeverEnding
{
    class GameObjectManager
    {
        private static Int64 gameObjectIdSequence;
        private static List<GameObject> gameObjects = new List<GameObject>();
        private static List<ForcibleObject> forcibleObjects = new List<ForcibleObject>();
        private static Dictionary<Vector2,AnimatedFloorObject> animatedFloorObjects = new Dictionary<Vector2,AnimatedFloorObject>();

        public static Int64 getGOSequence()
        {
            return gameObjectIdSequence++;
        }

        public static List<GameObject> GetAll()
        {
            return gameObjects;
        }

        public static List<ForcibleObject> GetAllForcibleGO()
        {
            if(forcibleObjects.Count == 0)
                foreach (ForcibleObject gameObject in gameObjects.OfType<ForcibleObject>())
                    forcibleObjects.Add(gameObject);

            return forcibleObjects;
        }

        public static List<AnimatedFloorObject> GetAllAnimatedFloorO()
        {
            return animatedFloorObjects.Values.ToList();
        }

        public static AnimatedFloorObject GetAnimatedFloorO(Vector2 position)
        {
            if(animatedFloorObjects.ContainsKey(position))
            {
                return animatedFloorObjects[position];
            }
            return null;

        }

        public static Boolean AddGO(GameObject gameObject)
        {
            if(gameObject == null)
                return false;

            gameObjects.Add(gameObject);
            return true;
        }

        public static Boolean AddFGO(ForcibleObject forcibleObject)
        {
            if (forcibleObject == null)
                return false;

            forcibleObjects.Add(forcibleObject);
            return true;
        }

        public static Boolean AddAFO(AnimatedFloorObject animatedFloorObject)
        {
            if (animatedFloorObject == null)
                return false;

            animatedFloorObjects.Add(animatedFloorObject.Position, animatedFloorObject);
            return true;
        }

        public static int GetCount()
        {
            return gameObjects.Count;
        }

    }
}

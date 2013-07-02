using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using NeverEnding.Config;

namespace NeverEnding
{
    class Helper
    {
        public static Vector2 ParseDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.None:
                    return new Vector2(0, 0);
                case Direction.North:
                    return new Vector2(0, -1);
                case Direction.East:
                    return new Vector2(1, 0);
                case Direction.South:
                    return new Vector2(0, 1);
                case Direction.West:
                    return new Vector2(-1, 0);
            }

            return new Vector2(0, 0);
        }
    }
}

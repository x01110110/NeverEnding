using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace NeverEnding.Config
{
    class GameConfig
    {
        public static int XWidth = 800;
        public static int YHeight = 600;
        public static int TileHeight = 16;
        public static int TileWidth = 16;
        public static float Scale = 1f;
        //RandBegrenzungen
        public static Rectangle NorthWall = new Rectangle(-1, -1, XWidth, 1);
        public static Rectangle EastWall = new Rectangle(XWidth, -1, 1, YHeight);
        public static Rectangle SouthWall = new Rectangle(-1, YHeight, XWidth, 1);
        public static Rectangle WestWall = new Rectangle(-1, -1, 1, YHeight);
    }
}

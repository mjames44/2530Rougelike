using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityMain : Map
    {
        public MapCityMain(int ep)
            : base(ep)
        {
            FileName = "mapCityMain.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 501, 502, 503, 504, 505, 506, 507, 508, 509 });
        }

        protected override void AddTiles()
        {
            TileInfo[0].Color = ConsoleColor.DarkYellow;
            TileInfo[1].Color = ConsoleColor.Gray;

            TileInfo.Add(11, new Tile(ConsoleColor.Yellow, '*'));
            TileInfo.Add(12, new Tile(ConsoleColor.Blue, '%'));
            TileInfo.Add(13, new Tile(ConsoleColor.Magenta, '#'));
            TileInfo.Add(501, new Tile(ConsoleColor.DarkYellow, '.'));
            TileInfo.Add(502, new Tile(ConsoleColor.DarkYellow, '.'));
            TileInfo.Add(503, new Tile(ConsoleColor.DarkYellow, '.'));
            TileInfo.Add(504, new Tile(ConsoleColor.White, '-'));
            TileInfo.Add(505, new Tile(ConsoleColor.White, '-'));
            TileInfo.Add(506, new Tile(ConsoleColor.White, '-'));
            TileInfo.Add(507, new Tile(ConsoleColor.White, '-'));
            TileInfo.Add(508, new Tile(ConsoleColor.White, '-'));
            TileInfo.Add(509, new Tile(ConsoleColor.White, '-'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 501:
                    Program.newMap = new MapForest1(1);
                    Program.CheckSpace = typeof(MapForest1).GetMethod("CheckSpace");
                    break;
                case 503:
                    Program.newMap = new MapCastle(0);
                    Program.CheckSpace = typeof(MapCastle).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 78, 37 };
                    break;
                case 1:
                    StartingPosition = new int[] { 0, 0 };
                    break;
                case 2:
                    StartingPosition = new int[] { 48, 1 };
                    break;
            }
        }
    }
}

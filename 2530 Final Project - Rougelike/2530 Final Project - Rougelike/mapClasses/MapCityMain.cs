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
                case 504:
                    Program.newMap = new MapCityArmorySmith(0, TileInfo);
                    Program.CheckSpace = typeof(MapCityArmorySmith).GetMethod("CheckSpace");
                    break;
                case 505:
                    Program.newMap = new MapCityArmorySmith(1, TileInfo);
                    Program.CheckSpace = typeof(MapCityArmorySmith).GetMethod("CheckSpace");
                    break;
                case 506:
                    Program.newMap = new MapCityHouse1(0, TileInfo);
                    Program.CheckSpace = typeof(MapCastle).GetMethod("CheckSpace");
                    break;
                case 507:
                    Program.newMap = new MapCityHouse2(0, TileInfo);
                    Program.CheckSpace = typeof(MapCastle).GetMethod("CheckSpace");
                    break;
                case 508:
                    Program.newMap = new MapCityBarracks(0, TileInfo);
                    Program.CheckSpace = typeof(MapCastle).GetMethod("CheckSpace");
                    break;
                case 509:
                    Program.newMap = new MapCityStables(0, TileInfo);
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
                case 3:
                    StartingPosition = new int[] { 10, 33 };
                    break;
                case 4:
                    StartingPosition = new int[] { 17, 33 };
                    break;
                case 5:
                    StartingPosition = new int[] { 24, 36 };
                    break;
                case 6:
                    StartingPosition = new int[] { 34, 13 };
                    break;
                case 7:
                    StartingPosition = new int[] { 64, 33 };
                    break;
                case 8:
                    StartingPosition = new int[] { 80, 11 };
                    break;
                case 9:
                    StartingPosition = new int[] { 10, 33 };
                    break;
            }
        }
    }
}

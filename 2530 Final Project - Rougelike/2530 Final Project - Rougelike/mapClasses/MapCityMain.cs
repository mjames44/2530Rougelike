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
            TileInfo[99].Color = TileInfo[0].Color;

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
                    Game.newMap = new MapForest1(1);
                    Game.CheckSpace = typeof(MapForest1).GetMethod("CheckSpace");
                    break;
                case 502:
                    Game.newMap = new MapForest2(0);
                    Game.CheckSpace = typeof(MapForest2).GetMethod("CheckSpace");
                    break;
                case 503:
                    Game.newMap = new MapCastle(0);
                    Game.CheckSpace = typeof(MapCastle).GetMethod("CheckSpace");
                    break;
                case 504:
                    Game.newMap = new MapCityArmorySmith(0);
                    Game.CheckSpace = typeof(MapCityArmorySmith).GetMethod("CheckSpace");
                    break;
                case 505:
                    Game.newMap = new MapCityArmorySmith(1);
                    Game.CheckSpace = typeof(MapCityArmorySmith).GetMethod("CheckSpace");
                    break;
                case 506:
                    Game.newMap = new MapCityHouse1(0);
                    Game.CheckSpace = typeof(MapCityHouse1).GetMethod("CheckSpace");
                    break;
                case 507:
                    Game.newMap = new MapCityBarracks(0);
                    Game.CheckSpace = typeof(MapCityBarracks).GetMethod("CheckSpace");
                    break;
                case 508:
                    Game.newMap = new MapCityHouse2(0);
                    Game.CheckSpace = typeof(MapCityHouse2).GetMethod("CheckSpace");
                    break;
                case 509:
                    Game.newMap = new MapCityStables(0);
                    Game.CheckSpace = typeof(MapCityStables).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 37,78 };
                    break;
                case 1:
                    StartingPosition = new int[] { 13,97 };
                    break;
                case 2:
                    StartingPosition = new int[] { 2,48 };
                    break;
                case 3:
                    StartingPosition = new int[] { 33, 10};
                    break;
                case 4:
                    StartingPosition = new int[] { 33, 17};
                    break;
                case 5:
                    StartingPosition = new int[] { 36, 24 };
                    break;
                case 6:
                    StartingPosition = new int[] { 13, 35};
                    break;
                case 7:
                    StartingPosition = new int[] { 22, 88 };
                    break;
                case 8:
                    StartingPosition = new int[] { 11, 80 };
                    break;
            }
        }
    }
}

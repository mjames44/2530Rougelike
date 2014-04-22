using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCastle : Map
    {
        public MapCastle(int ep)
            : base(ep)
        {
            FileName = "mapCastle.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 551, 552, 553, 554, 555 });
        }

        protected override void AddTiles()
        {
            TileInfo[1].Color = ConsoleColor.Gray;


            TileInfo.Add(11, new Tile(ConsoleColor.Yellow, '*'));
            TileInfo.Add(12, new Tile(ConsoleColor.Blue, '%'));
            TileInfo.Add(13, new Tile(ConsoleColor.Magenta, '#'));
            TileInfo.Add(551, new Tile(ConsoleColor.Gray, '.'));
            TileInfo.Add(552, new Tile(ConsoleColor.Gray, '.'));
            TileInfo.Add(553, new Tile(ConsoleColor.DarkYellow, '='));
            TileInfo.Add(554, new Tile(ConsoleColor.White, '-'));
            TileInfo.Add(555, new Tile(ConsoleColor.White, '-'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 551:
                    Program.newMap = new MapCityMain(2);
                    Program.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
                //case 552:
                //    Program.newMap = new MapCastleInside(0);
                //    Program.CheckSpace = typeof(MapCastleInside).GetMethod("CheckSpace");
                //    break;
                case 555:
                    Program.newMap = new MapCastleTowerLeft1(0);
                    Program.CheckSpace = typeof(MapCastleTowerLeft1).GetMethod("CheckSpace");
                    break;
                //case 554:
                //    Program.newMap = new MapCastleTowerRight1(0);
                //    Program.CheckSpace = typeof(MapCastleTowerRight1).GetMethod("CheckSpace");
                //    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0: // From city
                    StartingPosition = new int[] { 47, 38 };
                    break;
                case 1: // Tower Left
                    StartingPosition = new int[] { 87, 18 };
                    break;
                case 2: // Tower Right
                    StartingPosition = new int[] { 8, 18 };
                    break;
                case 3: // Palace
                    StartingPosition = new int[] { 47, 5 };
                    break;
            }
        }
    }
}

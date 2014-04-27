using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityArmorySmith : Map
    {
        public MapCityArmorySmith(int ep, Dictionary<int, Tile> tileInfo)
            : base(ep)
        {
            FileName = "mapCityArmorySmith.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> {511, 512});
        }

        protected override void AddTiles()
        {
            TileInfo.Add(511, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(512, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 511 :
                    Program.newMap = new MapCityMain(3);
                    Program.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
                case 512:
                    Program.newMap = new MapCityMain(4);
                    Program.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 29, 42 };
                    break;
                case 1:
                    StartingPosition = new int[] { 29, 56 };
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class MapForest1 : Map
    {
        public MapForest1(int ep) : base(ep)
        {
            FileName = "mapForest1.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 1006 });
        }

        protected override void AddTiles()
        {
            TileInfo.Add(1001, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1002, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1003, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1004, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1005, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1006, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1006:
                    Program.newMap = new MapCityMain(0);
                    Program.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 5, 5 };
                    break;
                case 1:
                    StartingPosition = new int[] { 78,1 };
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityHouse2 : Map
    {
        public MapCityHouse2(int ep, Dictionary<int, Tile> tileInfo)
            : base(ep)
        {
            FileName = "mapCityHouse2.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> {513});
        }

        protected override void AddTiles()
        {
            TileInfo.Add(513, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 513 :
                    Program.newMap = new MapCityMain(6);
                    Program.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 27, 44 };
                    break;
            }
        }
    }
}

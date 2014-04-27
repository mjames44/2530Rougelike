using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityStables : Map
    {
        public MapCityStables(int ep, Dictionary<int, Tile> tileInfo)
            : base(ep, tileInfo)
        {
            FileName = "mapLevel0.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 551 });
        }

        protected override void AddTiles()
        {
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 551:
                    Program.newMap = new MapCityMain(8);
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
            }
        }
    }
}

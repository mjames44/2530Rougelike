using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityHouse1 : MapCityMain
    {
        public MapCityHouse1(int ep)
            : base(ep)
        {
            FileName = "mapCityHouse1.csv";

            ReadMap();
            base.AddTiles();
            StandableTiles.AddRange(new List<int> { 512 });
        }

        protected override void AddTiles()
        {
            TileInfo.Add(512, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 512:
                    Game.newMap = new MapCityMain(5);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 29, 50 };
                    break;
            }
        }
    }
}

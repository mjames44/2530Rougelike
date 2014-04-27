using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityArmorySmith : MapCityMain
    {
        public MapCityArmorySmith(int ep)
            : base(ep)
        {
            FileName = "mapCityArmorySmith.csv";

            ReadMap();
            base.AddTiles(); 
            StandableTiles.AddRange(new List<int> { 511, 512 });
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
                    Game.newMap = new MapCityMain(3);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
                case 512:
                    Game.newMap = new MapCityMain(4);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 29, 43 };
                    break;
                case 1:
                    StartingPosition = new int[] { 29, 57 };
                    break;
            }
        }
    }
}

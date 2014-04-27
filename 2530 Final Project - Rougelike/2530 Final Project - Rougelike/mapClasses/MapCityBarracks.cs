using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityBarracks : Map
    {
        public MapCityBarracks(int ep, Dictionary<int, Tile> tileInfo)
            : base(ep)
        {
            FileName = "mapCityBarracks.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 514 });
        }

        protected override void AddTiles()
        {
            TileInfo.Add(514, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 514:
                    Game.newMap = new MapCityMain(7);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 17, 61 };
                    break;
            }
        }
    }
}

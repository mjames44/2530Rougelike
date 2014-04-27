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

            for (int i = 0; i < 300; i++)
            {
                if (TileInfo.Keys.Contains(i + 400))
                {
                    TileInfo.Add(i + 400, new Tile(ConsoleColor.DarkGray, TileInfo[i].CharacterRepresentation));
                }
            }

            TileInfo.Add(901, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(902, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(903, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(904, new Tile(ConsoleColor.DarkGray, '.'));
            TileInfo.Add(905, new Tile(ConsoleColor.DarkGray, '.'));
            TileInfo.Add(906, new Tile(ConsoleColor.DarkGray, '.'));
            TileInfo.Add(907, new Tile(ConsoleColor.DarkGray, '.'));
            TileInfo.Add(908, new Tile(ConsoleColor.DarkGray, '.'));
            TileInfo.Add(909, new Tile(ConsoleColor.DarkGray, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 513 :
                    Game.newMap = new MapCityMain(6);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
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

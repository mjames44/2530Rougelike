using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapDungeon : Map
    {
        public MapDungeon(int ep)
            : base(ep)
        {
            FileName = "mapDungeon.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> {1514,1515});// tiles that lead to other  places
        }

        protected override void AddTiles()
        {
            TileInfo.Add(11, new Tile(ConsoleColor.Yellow, '*'));// add new tiles
            TileInfo.Add(12, new Tile(ConsoleColor.Cyan, '*'));
            TileInfo.Add(13, new Tile(ConsoleColor.Magenta, '*'));
            TileInfo.Add(1514, new Tile(ConsoleColor.White, '#'));
            TileInfo.Add(1515, new Tile(ConsoleColor.White, '.'));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                /*case 551 :
                    Program.newMap = new MapCityMain(0);
                    Program.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;*/
                //case 1501 :
                //    Program.newMap = new MapForest2(1);
                //    Program.CheckSpace = typeof(MapForest2).GetMethod("CheckSpace");
                //    break;
                case 1514:
                    Program.newMap = new MapDarkCastleMainFloor(5);
                    Program.CheckSpace = typeof(MapDarkCastleMainFloor).GetMethod("CheckSpace");
                    break;
                case 1515:
                    Program.newMap = new MapDarkCastle(2); //going into position
                    Program.CheckSpace = typeof(MapDarkCastle).GetMethod("CheckSpace");
                    break;
                //case 1509:
                //    Program.newMap = new MapForest2(2); //going into position
                //    Program.CheckSpace = typeof(MapForest2).GetMethod("CheckSpace");
                //    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 83, 15 };//start position from Dark Castle Main floor to Dungeon
                    break;
                case 1:
                    StartingPosition = new int[] { 98, 19 };//start position from Dark Castle to Dungeon secret passage
                    break;

            }
        }
    }
}

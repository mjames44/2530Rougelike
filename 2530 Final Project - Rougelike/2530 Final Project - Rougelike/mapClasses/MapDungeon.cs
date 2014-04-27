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
            TileInfo.Add(1514, new Tile(ConsoleColor.White, '#'));
            TileInfo.Add(1515, new Tile(ConsoleColor.White, '?'));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {

                case 1514://Trigger to go to map Dark Castle Main Floor
                    Program.newMap = new MapDarkCastleMainFloor(5);
                    Program.CheckSpace = typeof(MapDarkCastleMainFloor).GetMethod("CheckSpace");
                    break;
                case 1515://Trigger to go to map Dark Castle
                    Program.newMap = new MapDarkCastle(2); //going into position
                    Program.CheckSpace = typeof(MapDarkCastle).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 15, 83 };//start position from Dark Castle Main floor to Dungeon
                    break;
                case 1:
                    StartingPosition = new int[] { 19, 98 };//start position from Dark Castle to Dungeon secret passage
                    break;

            }
        }
    }
}

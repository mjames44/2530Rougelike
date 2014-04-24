using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapDarkCastleMainFloor : Map
    {
        public MapDarkCastleMainFloor(int ep)
            : base(ep)
        {
            FileName = "mapDarkCastleMainFloor.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> {1507,1508,1510,1511,1512,1513 });// trigger tiles that lead to other places
        }

        protected override void AddTiles()
        {

            TileInfo.Add(1507, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1508, new Tile(ConsoleColor.White, '#'));
            TileInfo.Add(1510, new Tile(ConsoleColor.White, '#'));
            TileInfo.Add(1511, new Tile(ConsoleColor.White, '#'));
            TileInfo.Add(1512, new Tile(ConsoleColor.White, '#'));
            TileInfo.Add(1513, new Tile(ConsoleColor.White, '#'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {

                case 1507://triggers to go to map Dark Castle
                    Program.newMap = new MapDarkCastle(1);
                    Program.CheckSpace = typeof(MapDarkCastle).GetMethod("CheckSpace");
                    break;
                case 1508://triggers to go to map Tower 1
                    Program.newMap = new MapTower1(0);
                    Program.CheckSpace = typeof(MapTower1).GetMethod("CheckSpace");
                    break;
                case 1510://triggers to go to map Tower 2
                    Program.newMap = new MapTower2(0);
                    Program.CheckSpace = typeof(MapTower2).GetMethod("CheckSpace");
                    break;
                case 1511://triggers to go to map Tower 3
                    Program.newMap = new MapTower3(0);
                    Program.CheckSpace = typeof(MapTower3).GetMethod("CheckSpace");
                    break;
                case 1512://triggers to go to map Tower 4
                    Program.newMap = new MapTower4(0);
                    Program.CheckSpace = typeof(MapTower4).GetMethod("CheckSpace");
                    break;
                case 1513://triggers to go to map Dungeon
                    Program.newMap = new MapDungeon(0); //going into position
                    Program.CheckSpace = typeof(MapDungeon).GetMethod("CheckSpace");
                    break;
 
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 12, 20 };//start position from DarkCastle to Dark Castle Main Floor
                    break;
                case 1:
                    StartingPosition = new int[] { 10, 4 };//start position from Tower 1 to Dark Castle Main Floor
                    break;
                case 2:
                    StartingPosition = new int[] { 10, 35 };//start position from Tower 2 to Dark Castle Main Floor
                    break;
                case 3:
                    StartingPosition = new int[] { 86, 35 };//start position from Tower 3 to Dark Castle Main Floor
                    break;
                case 4:
                    StartingPosition = new int[] { 86, 5 };//start position from Tower 4 to Dark Castle Main Floor
                    break;
                case 5:
                    StartingPosition = new int[] { 70, 17 };//start position from Dungeon to Dark Castle Main Floor
                    break;
            }
        }
    }
}

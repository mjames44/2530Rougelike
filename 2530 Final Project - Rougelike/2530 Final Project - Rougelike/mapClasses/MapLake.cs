using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapLake : Map
    {
        public MapLake(int ep)
            : base(ep)
        {
            FileName = "mapLake.csv";

            ReadMap();
            AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> {1012,1013,1014});// tiles that lead to other  places
        }
        private void AddCharacters()
        {
            MapCharacters.Add(new Troll(70, 27));
            MapCharacters.Add(new Troll(89, 32));
            MapCharacters.Add(new Troll(21, 31));
            MapCharacters.Add(new DarkDwarf(51, 14));
            MapCharacters.Add(new DarkDwarf(58, 3));            
            MapCharacters.Add(new DarkDwarf(13, 4));
            MapCharacters.Add(new Goblin (25, 26));
            
        }
        protected override void AddTiles()
        {

            TileInfo.Add(1012, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1013, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1014, new Tile(ConsoleColor.White, '.'));
            
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                 case 1012:
                    Program.newMap = new MapMountain(2);
                    Program.CheckSpace = typeof(MapMountain).GetMethod("CheckSpace");
                    break;
                //case 1013:
                //    Program.newMap = new MapMountain(4); //going into position
                //    Program.CheckSpace = typeof(MapMountain).GetMethod("CheckSpace");
                //    break;
                //case 1014:
                //    Program.newMap = new MapForest3(2); //going into position
                //    Program.CheckSpace = typeof(MapForest3).GetMethod("CheckSpace");
                //    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 28, 38 };//start position from Mountain to lake
                    break;
                case 1:
                    StartingPosition = new int[] { 58, 2 };//start position from Mountain (small path) to lake
                    break;
                case 2:
                    StartingPosition = new int[] { 98, 32 };//start position from Forest 3 to lake
                    break;

            }
        }
    }
}

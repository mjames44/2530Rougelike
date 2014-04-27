using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapMountain : Map
    {
        public MapMountain(int ep) : base (ep)
        {
            FileName = "mapMountain.csv";

            ReadMap();
            AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> {1501,1502,1503,1509, 1520 });// tiles that lead to other  places
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
            TileInfo.Add(11, new Tile(ConsoleColor.Yellow, '*'));// add new tiles
            TileInfo.Add(12, new Tile(ConsoleColor.Cyan, '*'));
            TileInfo.Add(13, new Tile(ConsoleColor.Magenta, '*'));
            TileInfo.Add(1501, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1502, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1503, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1509, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1520, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {

                case 1501 :
                    Game.newMap = new MapForest2(1);
                    Game.CheckSpace = typeof(MapForest2).GetMethod("CheckSpace");
                    break;
                case 1502:
                    Game.newMap = new MapCave(0);
                    Game.CheckSpace = typeof(MapCave).GetMethod("CheckSpace");
                    break;
                case 1503:
                    Game.newMap = new MapLake(0); //going into position
                    Game.CheckSpace = typeof(MapLake).GetMethod("CheckSpace");
                    break;
                case 1520:
                    Game.newMap = new MapLake(1); //going into position
                    Game.CheckSpace = typeof(MapLake).GetMethod("CheckSpace");
                    break;
                case 1509:
                    Game.newMap = new MapForest2(3); //going into position
                    Game.CheckSpace = typeof(MapForest2).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 37, 28 };//start position from forest 2 to mountain
                    break;
                case 1:
                    StartingPosition = new int[] { 2, 58 };//start position from cave to mountain
                    break;
                case 2:
                    StartingPosition = new int[] { 32, 97 };//start position from lake to mountain
                    break;
                case 3:
                    StartingPosition = new int[] { 37, 40 };//start position from forest 2 (small path) to mountain
                    break;
                case 4:
                    StartingPosition = new int[] { 17, 97 };//start position from Lake (small path) to mountain
                    break;
            }
        }
    }
}

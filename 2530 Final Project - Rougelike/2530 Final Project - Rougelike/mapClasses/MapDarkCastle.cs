using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapDarkCastle : Map
    {
        public MapDarkCastle(int ep)
            : base(ep)
        {
            FileName = "mapDarkCastle.csv";

            ReadMap();
            AddCharacters();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 1504, 1505, 1506 });// tiles that lead to other  places
        }
        private void AddCharacters()
        {
            MapCharacters.Add(new Ogre(50, 15));
            MapCharacters.Add(new Ogre(79, 35));
            MapCharacters.Add(new Ogre(24, 27));
            MapCharacters.Add(new KillerRabbit(92, 25));
            MapCharacters.Add(new KillerRabbit(24, 3));
            MapCharacters.Add(new Goblin(5, 30));
            MapCharacters.Add(new Goblin(10, 24));
            MapCharacters.Add(new GiantLeech(42, 21));
            

        }
        protected override void AddTiles()
        {
            TileInfo.Add(11, new Tile(ConsoleColor.Yellow, '*'));// add new tiles
            TileInfo.Add(12, new Tile(ConsoleColor.Cyan, '*'));
            TileInfo.Add(13, new Tile(ConsoleColor.Magenta, '*'));
            TileInfo.Add(1504, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1505, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1506, new Tile(ConsoleColor.White, '.'));
            
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {

                //case 1504 ://to MapForest4
                //    Program.newMap = new MapForest4(0);
                //    Program.CheckSpace = typeof(MapForest4).GetMethod("CheckSpace");
                //    break;
                case 1505://to MapDarkCastleMainFloor
                    Program.newMap = new MapDarkCastleMainFloor(0);
                    Program.CheckSpace = typeof(MapDarkCastleMainFloor).GetMethod("CheckSpace");
                    break;
                case 1506://secret passage to MapDungeon
                    Program.newMap = new MapDungeon(1); //going into position
                    Program.CheckSpace = typeof(MapDungeon).GetMethod("CheckSpace");
                    break;

            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 1, 33 };//start position from forest 4 to Dark Castle
                    break;
                case 1:
                    StartingPosition = new int[] { 53, 20 };//start position from Dark Castle Main Room to Dark Castle
                    break;
                case 2:
                    StartingPosition = new int[] { 88, 21 };//start position from Dungeon secret passage to Dark Castle 
                    break;

            }
        }
    }
}

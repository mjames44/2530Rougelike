using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapDarkCastleDungeon : Map
    {
        public MapDarkCastleDungeon(int ep)
            : base(ep)
        {
            FileName = "mapDungeon.csv";

            ReadMap();
            AddCharacters();
            AddTiles();
            StandableTiles.AddRange(new List<int> {1514,1515});// tiles that lead to other  places
        }

        private void AddCharacters()
        {
            MapCharacters.Add(new Troll(70, 26));
            MapCharacters.Add(new Goblin(65, 11));
            MapCharacters.Add(new Troll(27, 27));
            MapCharacters.Add(new Goblin(53, 35));
            MapCharacters.Add(new Demon(5, 25));
            MapCharacters.Add(new Bat(4, 4));
            MapCharacters.Add(new Ghost(52, 15));
            MapCharacters.Add(new Bat(70, 35));
            MapCharacters.Add(new Wraith(35, 5));
            MapCharacters.Add(new Giant(94, 18));
            MapCharacters.Add(new Bat(80, 5));
            MapCharacters.Add(new Princess(5, 38));
        }

        protected override void AddTiles()
        {
            TileInfo.Add(1514, new Tile(ConsoleColor.White, '<'));
            TileInfo.Add(1515, new Tile(ConsoleColor.White, '>'));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {

                case 1514://Trigger to go to map Dark Castle Main Floor
                    Game.newMap = new MapDarkCastleMainFloor(5);
                    Game.CheckSpace = typeof(MapDarkCastleMainFloor).GetMethod("CheckSpace");
                    break;
                case 1515://Trigger to go to map Dark Castle
                    Game.newMap = new MapDarkCastle(2); //going into position
                    Game.CheckSpace = typeof(MapDarkCastle).GetMethod("CheckSpace");
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

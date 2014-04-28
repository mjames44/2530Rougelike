using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2530_Final_Project___Rougelike
{
    class MapForest4 : Map
    {
        public MapForest4(int ep)
            : base(ep)
        {
            FileName = "mapForest4.csv";

            ReadMap();
            AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> { 1017, 1018 });

        }

        private void AddCharacters()
        {
            MapCharacters.Add(new Giant(6, 8));
            MapCharacters.Add(new Giant(6, 8));
            MapCharacters.Add(new Giant(6, 8));
            MapCharacters.Add(new Giant(6, 8));
            MapCharacters.Add(new Giant(6, 8));
            MapCharacters.Add(new Giant(6, 8));
            MapCharacters.Add(new Giant(6, 8));
            MapCharacters.Add(new Giant(6, 8));
            MapCharacters.Add(new Giant(6, 8));
        }

        protected override void AddTiles()
        {
            TileInfo.Add(1017, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1018, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1017:
                    Game.newMap = new MapForest2(5);
                    Game.CheckSpace = typeof(MapForest2).GetMethod("CheckSpace");
                    break;
                case 1018:
                   Game.newMap = new MapDarkCastle(0);
                    Game.CheckSpace = typeof(MapDarkCastle).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 2, 17 };
                    break;
                case 1:
                    StartingPosition = new int[] { 33, 97 };
                    break;
            }
        }
    }
}

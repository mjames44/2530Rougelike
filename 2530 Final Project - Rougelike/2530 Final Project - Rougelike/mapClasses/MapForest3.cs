using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2530_Final_Project___Rougelike
{
    class MapForest3 : Map
    {
        public MapForest3(int ep)
            : base(ep)
        {
            FileName = "mapForest3.csv";

            ReadMap();
            AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> { 1015, 1016 });

        }

        private void AddCharacters()
        {
            MapCharacters.Add(new Troll(70, 30));
            MapCharacters.Add(new Troll(73, 23));
            MapCharacters.Add(new Giant(56, 14));
            MapCharacters.Add(new Orc(42, 36));
            MapCharacters.Add(new Bat(90, 16));
            MapCharacters.Add(new Bat(28, 5));  
        }

        protected override void AddTiles()
        {
            TileInfo.Add(1015, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1016, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1015:
                    Game.newMap = new MapLake(2);
                    Game.CheckSpace = typeof(MapLake).GetMethod("CheckSpace");
                    break;
                case 1016:
                    Game.newMap = new MapForest2(4);
                    Game.CheckSpace = typeof(MapForest2).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 2, 87 };
                    break;
                case 1:
                    StartingPosition = new int[] { 25, 2 };
                    break;
            }
        }
    }

}

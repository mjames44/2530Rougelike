using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike.mapClasses
{
    class MapForest1AbandonedHouse : Map
    {
        public MapForest1AbandonedHouse(int ep)
            : base(ep)
        {
            FileName = "mapForest1AbandonedHouse.csv";

            ReadMap();
            AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> { 1019 });

        }
        
        protected override void AddTiles()
        {
            TileInfo.Add(1019, new Tile(ConsoleColor.White, '.'));          
        }

        private void AddCharacters()
        {
            MapCharacters.Add(new GhostGuy(4, 4));
        }
        
        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1019:
                    Game.newMap = new MapForest1(3);
                    Game.CheckSpace = typeof(MapForest1).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
          switch(entryPoint)
            {
                case 0:
                    StartingPosition = new int[] {1, 5};
                break;
            }
        }

    }
}

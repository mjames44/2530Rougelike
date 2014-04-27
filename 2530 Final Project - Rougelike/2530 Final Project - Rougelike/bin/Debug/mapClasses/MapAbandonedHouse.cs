using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike.mapClasses
{
    class MapAbandonedHouse : Map
    {
        public MapAbandonedHouse(int ep)
            : base(ep)
        {
            FileName = "mapAbandonedHouse.csv";

            ReadMap();
            AddTiles();
            //  AddCharacters();
            StandableTiles.AddRange(new List<int> { 1019 });

        }
        
        protected override void AddTiles()
        {
            TileInfo.Add(1019, new Tile(ConsoleColor.White, '.'));          
        }

      public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1019:
                    Program.newMap = new MapForest1(3);
                    Program.CheckSpace = typeof(MapForest1).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
          switch(entryPoint)
            {
                case 0:
                    StartingPosition = new int[] {5, 1};
                break;
            }
        }

    }
}

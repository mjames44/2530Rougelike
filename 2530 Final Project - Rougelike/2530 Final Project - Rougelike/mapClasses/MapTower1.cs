using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapTower1 : Map
    {
        public MapTower1(int ep)
            : base(ep)
        {
            FileName = "mapTower1.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> {1516});// trigger tiles that lead to other  places
        }

        protected override void AddTiles()
        {

            TileInfo.Add(1516, new Tile(ConsoleColor.White, '#'));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1516://Trigger to go to map Dark Castle Main Floor
                    Program.newMap = new MapDarkCastleMainFloor(1);
                    Program.CheckSpace = typeof(MapDarkCastleMainFloor).GetMethod("CheckSpace");
                    break;
            
 
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 4, 3 };//start position from DarkCastle Main Floor to Tower 1
                    break;

            }
        }
    }
}

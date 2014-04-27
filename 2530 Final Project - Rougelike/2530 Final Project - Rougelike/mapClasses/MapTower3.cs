using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapTower3 : Map
    {
        public MapTower3(int ep)
            : base(ep)
        {
            FileName = "mapTower3.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> {1518});// trigger tiles that lead to other  places
        }

        protected override void AddTiles()
        {

            TileInfo.Add(1518, new Tile(ConsoleColor.White, '#'));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1518://Trigger to go to map Dark Castle Main Floor
                    Game.newMap = new MapDarkCastleMainFloor(3);
                    Game.CheckSpace = typeof(MapDarkCastleMainFloor).GetMethod("CheckSpace");
                    break;
            
 
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 4, 3 };//start position from DarkCastle Main Floor to Tower 3
                    break;

            }
        }
    }
}

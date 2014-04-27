using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapTower4 : Map
    {
        public MapTower4(int ep)
            : base(ep)
        {
            FileName = "mapTower4.csv";

            ReadMap();
            AddCharacters();
            AddTiles();
            StandableTiles.AddRange(new List<int> {1519});// trigger tiles that lead to other  places
        }

        private void AddCharacters()
        {
            MapCharacters.Add(new Wraith(5, 2));

        }

        protected override void AddTiles()
        {

            TileInfo.Add(1519, new Tile(ConsoleColor.White, '#'));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
               case 1519://Trigger to go to map Dark Castle Main Floor
                    Game.newMap = new MapDarkCastleMainFloor(4);
                    Game.CheckSpace = typeof(MapDarkCastleMainFloor).GetMethod("CheckSpace");
                    break;
            
 
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 4, 6 };//start position from DarkCastle Main Floor to Tower 1
                    break;

            }
        }
    }
}

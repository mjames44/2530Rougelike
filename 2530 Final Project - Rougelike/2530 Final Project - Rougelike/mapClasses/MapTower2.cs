using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapTower2 : Map
    {
        TitaniumArmor TArmor = new TitaniumArmor();

        public MapTower2(int ep)
            : base(ep)
        {
            FileName = "mapTower2.csv";

            ReadMap();
            AddCharacters();
            AddTiles();
            StandableTiles.AddRange(new List<int> {1517, 1527});// trigger tiles that lead to other  places
        }

        private void AddCharacters()
        {
            MapCharacters.Add(new TowerSpirit(5, 2));

        }

        protected override void AddTiles()
        {

            TileInfo.Add(1517, new Tile(ConsoleColor.White, '#'));
            TileInfo.Add(1527, new Tile(TArmor.Color, TArmor.CharacterRepresentation));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1517://Trigger to go to map Dark Castle Main Floor
                    Game.newMap = new MapDarkCastleMainFloor(2);
                    Game.CheckSpace = typeof(MapDarkCastleMainFloor).GetMethod("CheckSpace");
                    break;
                case 1527:
                    Game.AddItem(TArmor);
                    MapSpace[8][9] = 0;
                    break;
            
 
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 4, 3 };//start position from DarkCastle Main Floor to Tower 2
                    break;

            }
        }
    }
}

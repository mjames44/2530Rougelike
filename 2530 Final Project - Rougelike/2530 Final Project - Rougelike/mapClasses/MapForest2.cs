using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike.mapClasses
{
    class MapForest2 : Map
    {
        public MapForest2(int ep) : base(ep)
        {
                FileName = "mapForest2.csv";

                ReadMap();
                AddTiles();
                AddCharacters();
                StandableTiles.AddRange(new List<int> { 1007, 1008, 1009, 1020, 1010, 1011});

        }

        private void AddCharacters()
        {
            MapCharacters.Add(new Troll(70, 27));
            MapCharacters.Add(new Goblin(70, 10));
            MapCharacters.Add(new Troll(27, 27));
            MapCharacters.Add(new Goblin(53, 35));
            MapCharacters.Add(new RandomGuy(5,15));
        }

        protected override void AddTiles()
        {
            TileInfo.Add(1002, new Tile(healthPot.Color, healthPot.CharacterRepresentation));
            TileInfo.Add(1003, TileInfo[100]);
            TileInfo.Add(1004, new Tile(ConsoleColor.White, '*'));
            TileInfo.Add(1005, new Tile(ConsoleColor.White, '*'));
            TileInfo.Add(1006, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(2001, new Tile(dagger.Color, dagger.CharacterRepresentation));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1006:
                    Program.newMap = new MapCityMain(0);
                    Program.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
                case 2001 :
                    Program.AddItem(dagger);
                    MapSpace[9][6] = 0;
                    break;
                case 1002 :
                    Program.AddItem(healthPot);
                    MapSpace[37][53] = 0;
                    break;
                case 1004 :
                    MapSpace[29][53] = 0;
                    break;
                case 1005 :
                    MapSpace[34][15] = 1003;
                    break;
                case 1003 :
                    Program.newMap = new MapAbandonedHouse(0);
                    Program.CheckSpace = typeof(MapAbandonedHouse).GetMethod("CheckSpace");
                    break;

            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 5, 5 };
                    break;
                case 1:
                    StartingPosition = new int[] { 78,1 };
                    break;
                case 3:
                    StartingPosition = new int[] { 33, 15 };
                    break;
            }
        }
    }
    }
}

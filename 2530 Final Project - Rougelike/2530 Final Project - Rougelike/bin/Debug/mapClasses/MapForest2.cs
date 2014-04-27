using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike.mapClasses
{
    class MapForest2 : Map
    {
        WoodenHelmet woodenHelmet = new WoodenHelmet();

        public MapForest2(int ep)
            : base(ep)
        {
            FileName = "mapForest2.csv";

            ReadMap();
            AddTiles();
            //AddCharacters();
            StandableTiles.AddRange(new List<int> { 1007, 1008, 1009, 1010, 1011, 1020 });

        }

        private void AddCharacters()
        {
            
        }

        protected override void AddTiles()
        {
            TileInfo.Add(1007, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1008, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1009, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1010, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1011, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1020, new Tile(woodenHelmet.Color, woodenHelmet.CharacterRepresentation));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 1007:
                    Game.newMap = new MapCityMain(1);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
                case 1020:
                    Game.AddItem(woodenHelmet);
                    MapSpace[3][59] = 0;
                    break;
                case 1008:
                    Game.newMap = new MapMountain(0);
                    Game.CheckSpace = typeof(MapMountain).GetMethod("CheckSpace");
                    break;
                case 1009:
                    Game.newMap = new MapMountain(3);
                    Game.CheckSpace = typeof(MapMountain).GetMethod("CheckSpace");
                    break;
             /*   case 1010:
                    Program.newMap = new MapForest3(1);
                    Program.CheckSpace = typeof(MapForest3).GetMethod("CheckSpace");
                case 1011:
                    Program.newMap = new MapForest4(0);
                    Program.CheckSpace = typeof(MapForest4).GetMethod("CheckSpace");
                    break;*/
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 2, 12 };
                    break;
                case 1:
                    StartingPosition = new int[] { 78, 1 };
                    break;
                case 3:
                    StartingPosition = new int[] { 33, 15 };
                    break;
            }
        }
    }
}

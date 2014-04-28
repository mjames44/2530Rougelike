﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
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
            AddCharacters();
            StandableTiles.AddRange(new List<int> { 1007, 1008, 1009, 1010, 1011, 1020 });

        }

        private void AddCharacters()
        {
            MapCharacters.Add(new Troll(70, 30));
            MapCharacters.Add(new Goblin(50,3));
            MapCharacters.Add(new Goblin(58, 4));
            MapCharacters.Add(new Orc(25, 15));
            MapCharacters.Add(new Bat(5, 6));
            MapCharacters.Add(new Troll(69, 29));
 
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
                case 1010:
                    Game.newMap = new MapForest3(1);
                    Game.CheckSpace = typeof(MapForest3).GetMethod("CheckSpace");
                    break;
                case 1011:
                    Game.newMap = new MapForest4(0);
                    Game.CheckSpace = typeof(MapForest4).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 12, 2 };
                    break;
                case 1:
                    StartingPosition = new int[] { 2, 28 };
                    break;
                case 3:
                    StartingPosition = new int[] { 2, 40 };
                    break;
                case 4:
                    StartingPosition = new int[] { 27, 97 };
                    break;
                case 5:
                    StartingPosition = new int[] { 38, 18 };
                    break;
            }
        }
    }
}

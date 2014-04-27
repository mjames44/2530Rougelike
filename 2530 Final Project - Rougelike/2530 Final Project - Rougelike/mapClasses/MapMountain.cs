﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapMountain : Map
    {
        public MapMountain(int ep) : base (ep)
        {
            FileName = "mapMountain.csv";

            ReadMap();
            AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> {1501,1502,1503,1509 });// tiles that lead to other  places
        }
        private void AddCharacters()
        {
            MapCharacters.Add(new Troll(70, 27));
            MapCharacters.Add(new Troll(89, 32));
            MapCharacters.Add(new Troll(21, 31));
            MapCharacters.Add(new DarkDwarf(51, 14));
            MapCharacters.Add(new DarkDwarf(58, 3));            
            MapCharacters.Add(new DarkDwarf(13, 4));
            MapCharacters.Add(new Goblin (25, 26));
            
        }
        protected override void AddTiles()
        {
            TileInfo.Add(11, new Tile(ConsoleColor.Yellow, '*'));// add new tiles
            TileInfo.Add(12, new Tile(ConsoleColor.Cyan, '*'));
            TileInfo.Add(13, new Tile(ConsoleColor.Magenta, '*'));
            TileInfo.Add(1501, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1502, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1503, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1509, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                /*case 551 :
                    Program.newMap = new MapCityMain(0);
                    Program.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;*/
                //case 1501 :
                //    Program.newMap = new MapForest2(1);
                //    Program.CheckSpace = typeof(MapForest2).GetMethod("CheckSpace");
                //    break;
                case 1502:
                    Program.newMap = new MapCave(0);
                    Program.CheckSpace = typeof(MapCave).GetMethod("CheckSpace");
                    break;
                //case 1503:
                //    Program.newMap = new MapLake(0); //going into position
                //    Program.CheckSpace = typeof(MapLake).GetMethod("CheckSpace");
                //    break;
                //case 1509:
                //    Program.newMap = new MapForest2(2); //going into position
                //    Program.CheckSpace = typeof(MapForest2).GetMethod("CheckSpace");
                //    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 28, 38 };//start position from forest 2 to mountain
                    break;
                case 1:
                    StartingPosition = new int[] { 58, 2 };//start position from cave to mountain
                    break;
                case 2:
                    StartingPosition = new int[] { 98, 32 };//start position from lake to mountain
                    break;
                case 3:
                    StartingPosition = new int[] { 40, 38 };//start position from forest 2 (small path) to mountain
                    break;
                case 4:
                    StartingPosition = new int[] { 40, 38 };//start position from Lake (small path) to mountain
                    break;
            }
        }
    }
}

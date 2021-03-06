﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapLake : Map
    {
        public MapLake(int ep)
            : base(ep)
        {
            FileName = "mapLake.csv";

            ReadMap();
            AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> {1012,1013,1014, 1021});// tiles that lead to other places
        }
        private void AddCharacters()
        {
            MapCharacters.Add(new Troll(3, 8));
            MapCharacters.Add(new Troll(5, 21));
            MapCharacters.Add(new Troll(17, 36));
            MapCharacters.Add(new DarkDwarf(38, 34));
            MapCharacters.Add(new DarkDwarf(44, 31));            
            MapCharacters.Add(new DarkDwarf(68, 33));
            MapCharacters.Add(new Goblin (85, 35));
            MapCharacters.Add(new OldManAtTheLake(41, 23));
            
        }
        protected override void AddTiles()
        {

            TileInfo.Add(1012, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1013, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1014, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1021, new Tile(ConsoleColor.DarkYellow, '='));
            
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                 case 1012:
                    Game.newMap = new MapMountain(2);
                    Game.CheckSpace = typeof(MapMountain).GetMethod("CheckSpace");
                    break;
                case 1013:
                    Game.newMap = new MapMountain(4); //going into position
                    Game.CheckSpace = typeof(MapMountain).GetMethod("CheckSpace");
                    break;
                case 1014:
                    Game.newMap = new MapForest3(0); //going into position
                    Game.CheckSpace = typeof(MapForest3).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 32, 2 };//start position from Mountain to lake
                    break;
                case 1:
                    StartingPosition = new int[] { 16, 1 };//start position from Mountain (small path) to lake
                    break;
                case 2:
                    StartingPosition = new int[] { 38, 87 };//start position from Forest 3 to lake
                    break;

            }
        }
    }
}

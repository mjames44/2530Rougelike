﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCastle : Map
    {
        public MapCastle(int ep)
            : base(ep)
        {
            FileName = "mapCastle.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 551, 552, 553, 554, 555 });
        }

        protected override void AddTiles()
        {
            TileInfo[1].Color = ConsoleColor.Gray;


            TileInfo.Add(11, new Tile(ConsoleColor.Yellow, '*'));
            TileInfo.Add(12, new Tile(ConsoleColor.Blue, '%'));
            TileInfo.Add(13, new Tile(ConsoleColor.Magenta, '#'));
            TileInfo.Add(551, new Tile(ConsoleColor.Gray, '.'));
            TileInfo.Add(552, new Tile(ConsoleColor.Gray, '.'));
            TileInfo.Add(553, new Tile(ConsoleColor.DarkYellow, '='));
            TileInfo.Add(554, new Tile(ConsoleColor.White, '-'));
            TileInfo.Add(555, new Tile(ConsoleColor.White, '-'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 551:
                    Game.newMap = new MapCityMain(2);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
                case 552:
                    Game.newMap = new MapCastlePalace(0);
                    Game.CheckSpace = typeof(MapCastlePalace).GetMethod("CheckSpace");
                    break;
                case 555:
                    Game.newMap = new MapCastleTowerLeft1(0);
                    Game.CheckSpace = typeof(MapCastleTowerLeft1).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0: // From city
                    StartingPosition = new int[] { 38, 47 };
                    break;
                case 1: // Tower Left
                    StartingPosition = new int[] { 18, 87 };
                    break;
                case 3: // Palace
                    StartingPosition = new int[] { 6, 47 };
                    break;
            }
        }
    }
}

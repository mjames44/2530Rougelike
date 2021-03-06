﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCastleTowerLeft2 : Map
    {
        public MapCastleTowerLeft2(int ep)
            : base(ep)
        {
            FileName = "mapCastleTowerLeft2.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 573, 574 });
        }

        protected override void AddTiles()
        {
            TileInfo[1].Color = ConsoleColor.Gray;

            TileInfo.Add(401, new Tile(ConsoleColor.DarkGray, (char)9618));
            TileInfo.Add(406, new Tile(ConsoleColor.DarkGray, (char)9617));
            TileInfo.Add(400, new Tile(ConsoleColor.DarkGray, '.'));
            TileInfo.Add(411, new Tile(ConsoleColor.DarkGray, '*'));
            TileInfo.Add(412, new Tile(ConsoleColor.DarkGray, '%'));
            TileInfo.Add(413, new Tile(ConsoleColor.DarkGray, '#'));
            TileInfo.Add(500, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(954, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(955, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(953, new Tile(ConsoleColor.DarkGray, '='));
            TileInfo.Add(951, new Tile(ConsoleColor.DarkGray, '.'));
            TileInfo.Add(571, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(576, new Tile(ConsoleColor.DarkGray, '+'));
            TileInfo.Add(572, new Tile(ConsoleColor.DarkGray, '>'));
            TileInfo.Add(971, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(972, new Tile(ConsoleColor.DarkGray, '>'));
            TileInfo.Add(976, new Tile(ConsoleColor.DarkGray, '+'));
            TileInfo.Add(573, new Tile(ConsoleColor.White, '<'));
            TileInfo.Add(574, new Tile(ConsoleColor.White, '>'));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 573:
                    Game.newMap = new MapCastleTowerLeft1(1);
                    Game.CheckSpace = typeof(MapCastleTowerLeft1).GetMethod("CheckSpace");
                    break;
                case 574:
                    Game.newMap = new MapCastleTowerLeft3(0);
                    Game.CheckSpace = typeof(MapCastleTowerLeft3).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 28, 46 };
                    break;
                case 1:
                    StartingPosition = new int[] { 16, 49 };
                    break;
            }
        }
    }
}
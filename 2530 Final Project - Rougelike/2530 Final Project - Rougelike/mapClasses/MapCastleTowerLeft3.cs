using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCastleTowerLeft3 : Map
    {
        public MapCastleTowerLeft3(int ep)
            : base(ep)
        {
            FileName = "mapCastleTowerLeft3.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 575, 578 });
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
            TileInfo.Add(575, new Tile(ConsoleColor.White, '>'));
            TileInfo.Add(578, new Tile(ConsoleColor.White, '<'));
            TileInfo.Add(973, new Tile(ConsoleColor.DarkGray, '>'));
            TileInfo.Add(974, new Tile(ConsoleColor.DarkGray, '>'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 578:
                    Program.newMap = new MapCastleTowerLeft2(1);
                    Program.CheckSpace = typeof(MapCastleTowerLeft2).GetMethod("CheckSpace");
                    break;
                case 575:
                    Program.newMap = new MapCastleTowerLeft4(0);
                    Program.CheckSpace = typeof(MapCastleTowerLeft4).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 16, 49};
                    break;
                case 1:
                    StartingPosition = new int[] { 20, 50};
                    break;
            }
        }
    }
}
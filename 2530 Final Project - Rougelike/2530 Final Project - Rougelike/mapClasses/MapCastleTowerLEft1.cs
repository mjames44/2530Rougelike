using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCastleTowerLeft1 : Map
    {
        public MapCastleTowerLeft1(int ep)
            : base(ep)
        {
            FileName = "mapCastleTowerLeft1.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 571, 572 });
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
            TileInfo.Add(954, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(955, new Tile(ConsoleColor.DarkGray, '-'));
            TileInfo.Add(953, new Tile(ConsoleColor.DarkGray, '='));
            TileInfo.Add(951, new Tile(ConsoleColor.DarkGray, '.'));
            TileInfo.Add(571, new Tile(ConsoleColor.White, '-'));
            TileInfo.Add(576, new Tile(ConsoleColor.White, '+'));
            TileInfo.Add(572, new Tile(ConsoleColor.White, '>'));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 571:
                    Program.newMap = new MapCastle(1);
                    Program.CheckSpace = typeof(MapCastle).GetMethod("CheckSpace");
                    break;
                case 572:
                    Program.newMap = new MapCastleTowerLeft2(0);
                    Program.CheckSpace = typeof(MapCastleTowerLeft2).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 6, 63};
                    break;
                case 1:
                    StartingPosition = new int[] { 28, 46 };
                    break;
            }
        }
    }
}
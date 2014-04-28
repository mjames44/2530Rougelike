using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCastlePalace : MapCastle
    {
        public MapCastlePalace(int ep)
            : base(ep)
        {
            FileName = "mapCastlePalace.csv";

            ReadMap();
            base.AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> { 556, 22, 25 });

            TileInfo[1].Color = ConsoleColor.Gray;
        }

        private void AddCharacters()
        {
            MapCharacters = new List<Character>();

            int[,] guardPositions = new int[,] { { 34, 1 }, { 34, 4 }, { 34, 7 }, 
            { 62, 1 }, { 62, 4 }, { 62, 7 }, { 45, 1 }, { 51, 1 }, { 30, 6 }, 
            { 66, 6 }, { 30, 20 }, { 43, 20 }, { 53, 20 }, { 66, 20 }, { 59, 20 },
            { 37, 20 }, { 30, 16 }, { 30, 11 }, { 66, 16 }, { 66, 11 } };

            for (int row = 0; row < guardPositions.GetLength(0); row++)
            {
                    MapCharacters.Add(new Guard(guardPositions[row,0], guardPositions[row,1]));
            }

            MapCharacters.Add(new King(41,3));
            MapCharacters.Add(new Advisor(44, 3));
            MapCharacters.Add(new GuardCaptain(38, 3));

        }

        protected override void AddTiles()
        {
            TileInfo.Add(21, new Tile(ConsoleColor.White, '*'));
            TileInfo.Add(22, new Tile(ConsoleColor.Red, '.'));
            TileInfo.Add(23, new Tile(ConsoleColor.White, '*'));
            TileInfo.Add(24, new Tile(ConsoleColor.White, '='));
            TileInfo.Add(25, new Tile(ConsoleColor.Blue, '.'));
            TileInfo.Add(556, new Tile(ConsoleColor.Red, '.'));


        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 556:
                    Game.newMap = new MapCastle(3);
                    Game.CheckSpace = typeof(MapCastle).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0: // From castle
                    StartingPosition = new int[] { 19, 48 };
                    break;
            }
        }
    }
}

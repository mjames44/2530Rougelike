using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCave : Map
    {
        public MapCave(int ep) : base (ep)
        {
            FileName = "mapCave.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 20, 1504});// tiles that lead to other  places
        }

        protected override void AddTiles()
        {
            TileInfo.Add(20, new Tile(ConsoleColor.Red, (char)9618));// add new tiles
            TileInfo[2].Color = ConsoleColor.Red;
            TileInfo[2].CharacterRepresentation = (char)9618;
            TileInfo.Add(1504, new Tile(ConsoleColor.White, '.'));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {

                case 1504://triggers to go to map mountain
                    Program.newMap = new MapMountain(1);
                    Program.CheckSpace = typeof(MapMountain).GetMethod("CheckSpace");
                    break;
                
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 50, 38 };//start position in cave
                    break;
                
            }
        }
    }
}

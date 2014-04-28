using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityStables : MapCityMain
    {
        public MapCityStables(int ep)
            : base(ep)
        {
            FileName = "mapCityStables.csv";

            ReadMap();

            base.AddTiles();
            StandableTiles.AddRange(new List<int> { 515 });
            AddCharacters();
        }

        protected override void AddTiles()
        {
            TileInfo.Add(515, new Tile(ConsoleColor.White, '.'));
        }

        public void AddCharacters()
        {
            MapCharacters = new List<Character>();

            MapCharacters.Add(new Horse(49, 10));
            MapCharacters.Add(new Horse(46, 13));
            MapCharacters.Add(new Horse(49, 19));
            MapCharacters.Add(new Horse(47, 22));
            MapCharacters.Add(new Goat(46, 27));
            MapCharacters.Add(new Goat(48, 30));
            MapCharacters.Add(new FemaleVillager(53, 15, "Beca"));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 515:
                    Game.newMap = new MapCityMain(8);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 17, 53 };
                    break;
            }
        }
    }
}

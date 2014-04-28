using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityBarracks : MapCityMain
    {
        public MapCityBarracks(int ep)
            : base(ep)
        {
            FileName = "mapCityBarracks.csv";

            ReadMap();
            base.AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> { 514 });
        }

        protected override void AddTiles()
        {
            TileInfo.Add(514, new Tile(ConsoleColor.White, '.'));
        }

        private void AddCharacters()
        {
            MapCharacters = new List<Character>();

            MapCharacters.Add(new Guard(53, 20));
            MapCharacters.Add(new Guard(53, 14));
            MapCharacters.Add(new Guard(41, 12));
            MapCharacters.Add(new Guard(58, 29));
            MapCharacters.Add(new Guard(58, 13));
            MapCharacters.Add(new Guard(40, 27));

            MapCharacters.Add(new BarracksCaptain(39,34));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 514:
                    Game.newMap = new MapCityMain(6);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 17, 61 };
                    break;
            }
        }
    }
}

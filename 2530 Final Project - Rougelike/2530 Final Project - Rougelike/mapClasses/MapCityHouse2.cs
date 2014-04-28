using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityHouse2 : MapCityMain
    {
        public MapCityHouse2(int ep)
            : base(ep)
        {
            FileName = "mapCityHouse2.csv";

            ReadMap();
            base.AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> { 513 });
        }

        private void AddCharacters()
        {
            MapCharacters = new List<Character>();

            MapCharacters.Add(new FemaleVillager(47, 15,"Penny"));
            MapCharacters.Add(new Child(54, 24,"maisy"));
            MapCharacters.Add(new Child(56, 16,"mario"));
        }

        protected override void AddTiles()
        {
            TileInfo.Add(513, new Tile(ConsoleColor.White, '.'));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 513:
                    Game.newMap = new MapCityMain(7);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 27, 45 };
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapLevel0 : Map
    {
        public MapLevel0(int ep) : base (ep)
        {
            FileName = "mapLevel0.csv";

            ReadMap();
            AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> {551});
        }

        protected override void AddTiles()
        {
        }

        private void AddCharacters()
        {
            MapCharacters.Add(new TestMonster(5, 10));
            MapCharacters.Add(new TestMonster(6, 10));
            MapCharacters.Add(new RandomGuy(5, 15));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 551 :
                    Program.newMap = new MapCityMain(0);
                    Program.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 5, 5 };
                    break;
            }
        }
    }
}

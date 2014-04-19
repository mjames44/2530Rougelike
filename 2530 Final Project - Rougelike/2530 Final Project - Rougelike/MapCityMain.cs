using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityMain : Map
    {
        public MapCityMain(int ep) : base(ep)
        {
            FileName = "mapCityMain.csv";

            ReadMap();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 501});
        }

        protected override void AddTiles()
        {
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 501:
                    Program.newMap = new MapLevel0(0);
                    Program.CheckSpace = typeof(MapLevel0).GetMethod("CheckSpace");
                    break;
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 78, 37 };
                    break;
            }
        }
    }
}

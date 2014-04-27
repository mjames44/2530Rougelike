using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike.mapClasses
{
    class MapAbandonedHouse : Map
    {
          public MapAbandonedHouse(int ep) : base(ep)
        {
            FileName = "mapAbandonedHouse.csv";

            ReadMap();
            AddTiles();
        //  AddCharacters();
            StandableTiles.AddRange(new List<int> { 1019 });

        }
        public override void CheckSpace(int mapValue)
        {
            throw new NotImplementedException();
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            throw new NotImplementedException();
        }

    }
}

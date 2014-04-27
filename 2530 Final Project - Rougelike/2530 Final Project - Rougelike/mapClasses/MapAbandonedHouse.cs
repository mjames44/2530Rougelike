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
            StandableTiles.AddRange(new List<int> { 1019 });

        }

          protected override void AddTiles()
          {
          }

          public override void CheckSpace(int mapValue)
          {
          }

          protected override void SetStartingPosition(int entryPoint)
          {
          }
    }
}

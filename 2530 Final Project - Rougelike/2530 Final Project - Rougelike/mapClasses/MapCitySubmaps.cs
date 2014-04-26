using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    abstract class MapCitySubmaps : Map
    {
        public MapCitySubmaps(int ep, Dictionary<int, Tile> tileInfo)
            : base(ep)
        {
            TileInfo = tileInfo;
        }

        protected override void AddTiles()
        {
            foreach (int el in TileInfo.Keys)
            {
                if (el < 100 || (el > 500 && el < 600))
                {
                    if (!TileInfo.Keys.Contains(el+400))
                    {
                        TileInfo.Add(el + 400, new Tile(ConsoleColor.DarkGray, 
                            TileInfo[el].CharacterRepresentation));
                    }
                }
            }

            for (int i = 0; i < 100; i++)
            {
                if (TileInfo.Keys.Contains(i + 400))
                    TileInfo[i + 400].Color = ConsoleColor.DarkGray;
            }
        }
    }
}

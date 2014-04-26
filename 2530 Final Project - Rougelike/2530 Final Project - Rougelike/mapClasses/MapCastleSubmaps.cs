using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCastleSubmaps : Map
    {
        public MapCastleSubmaps(int ep, Dictionary<int, Tile> tileInfo)
            : base(ep)
        {
            TileInfo = AddTiles(tileInfo);
        }

        protected override void AddTiles() { }

        private Dictionary<int, Tile> AddTiles(Dictionary<int, Tile> tileInfo)
        {
            Dictionary<int, Tile> tempDict = new Dictionary<int, Tile>();
            Dictionary<int, Tile> newDict = new Dictionary<int, Tile>();
            
            foreach (KeyValuePair<int, Tile> el in tileInfo)
            {
                tempDict.Add(el.Key, el.Value);
            }

            foreach (int el in tempDict.Keys)
            {
                if (el <= 300 || (el > 500 && el < 600))
                {
                    if (!tileInfo.Keys.Contains(el + 400))
                    {
                        newDict.Add(el + 400, new Tile(ConsoleColor.DarkGray,
                            tileInfo[el].CharacterRepresentation));
                    }
                }
            }

            foreach (KeyValuePair<int, Tile> el in TileInfo)
            {
                newDict.Add(el.Key, el.Value);
            }

            return newDict;
        }

        public override void CheckSpace(int mapValue) {}
        protected override void SetStartingPosition(int entryPoint) {}
    }
}

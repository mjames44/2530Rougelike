using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapLevel0
    {
        static String fileName;
        public static Dictionary<int, Tile> tileInfo;

        public MapLevel0()
        {
            fileName = "mapCityMain.csv";
            BuildTileInfo();
        }

        public int[][] ReadMap()
        {
            List<int[]> tempList = new List<int[]>();
            List<int> eachLine;
            string[] lineArray;
            string tempString;

            using (StreamReader sr = new StreamReader("maps/" + fileName))
            {
                while ((tempString = sr.ReadLine()) != null)
                {
                    eachLine = new List<int>();

                    lineArray = tempString.Split(',');

                    foreach (string el in lineArray)
                    {
                        eachLine.Add(int.Parse(el));
                    }

                    tempList.Add(eachLine.ToArray());
                }
            }
            return tempList.ToArray();
        }

        private void BuildTileInfo()
        {
            tileInfo = new Dictionary<int, Tile>();

            tileInfo.Add(0, new Tile(ConsoleColor.White, '.'));
            tileInfo.Add(1, new Tile(ConsoleColor.Red, (char)9618));
            tileInfo.Add(2, new Tile(ConsoleColor.Black, ' '));
            tileInfo.Add(3, new Tile(ConsoleColor.White, '>'));
            tileInfo.Add(4, new Tile(ConsoleColor.White, '<'));
        }
    }
}

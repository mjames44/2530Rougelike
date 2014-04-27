using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    abstract class Map
    {
        // Fields
        private Dictionary<int, Tile> tileInfo;

        // Properties
        public int[] StartingPosition { get; protected set; }
        public int[][] MapSpace { get; protected set; }
        public List<int> StandableTiles { get; protected set; }
        public Dictionary<int, Tile> TileInfo 
        {
            get
            {
                return tileInfo;
            }
            protected set
            {
                tileInfo = value;
            } 
        }
        public string FileName { get; protected set; }
        public List<Character> MapCharacters { get; protected set; }

        // Constructors
        public Map(int entryPoint)
        {
            // Basic list of standable tiles (open space, stairs, open door, etc)
            StandableTiles = new List<int> { 0, 3, 4 , 100};
            BuildTiles();
            SetStartingPosition(entryPoint);

            MapCharacters = new List<Character>();
        }

        // Methods
        public void ReadMap()
        {
            List<int[]> tempList = new List<int[]>();
            List<int> eachLine;
            string[] lineArray;
            string tempString;

            try
            {
                using (StreamReader sr = new StreamReader("maps/" + Game.pcName + FileName))
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
            }
            catch
            {
                using (StreamReader sr = new StreamReader("maps/" + FileName))
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
            }

            MapSpace = tempList.ToArray();
        }

        private void BuildTiles()
        {
            tileInfo = new Dictionary<int, Tile>();

            TileInfo.Add(0, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1, new Tile(ConsoleColor.Red, (char)9618));
            TileInfo.Add(2, new Tile(ConsoleColor.Black, ' '));
            TileInfo.Add(3, new Tile(ConsoleColor.White, '>'));
            TileInfo.Add(4, new Tile(ConsoleColor.White, '<'));
            TileInfo.Add(5, new Tile(ConsoleColor.Green, (char)9650));
            TileInfo.Add(6, new Tile(ConsoleColor.Blue, (char)9617));
            TileInfo.Add(99, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(100, new Tile(ConsoleColor.White, '-'));
            for (int i = 101; i <= 300; i++)
                TileInfo.Add(i, new Tile(ConsoleColor.White, '+'));
        }

        protected abstract void AddTiles();

        public abstract void CheckSpace(int mapValue);

        /* Method - SetStartingPosition
         * 
         * Some maps will have multiple places where characters can start from.
         * 
         * This method takes an int, the numbered value of the entry point,
         * and sets the starting position property appropriately so it can be
         * assigned to the player charcter on entry into the map.
         *  */
        protected abstract void SetStartingPosition(int entryPoint);
    }
}
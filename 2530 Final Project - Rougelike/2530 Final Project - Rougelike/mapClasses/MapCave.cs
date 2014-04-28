using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCave : Map
    {
        Excalibur ExcaliburSword = new Excalibur();

        public MapCave(int ep) : base (ep)
        {
            FileName = "mapCave.csv";

            ReadMap();
            AddCharacters();
            AddTiles();
            StandableTiles.AddRange(new List<int> { 20, 21, 1504, 1526});// tiles that lead to other  places
        }

        private void AddCharacters()
        {
            MapCharacters.Add(new Troll(70, 22));
            MapCharacters.Add(new Troll(89, 32));
            MapCharacters.Add(new Troll(21, 27));
            MapCharacters.Add(new Orc(3, 11));
            MapCharacters.Add(new Orc(75, 3));
            MapCharacters.Add(new Orc(21, 8));
            MapCharacters.Add(new DarkDwarf (25, 37));
            MapCharacters.Add(new Bat(50, 27));
            MapCharacters.Add(new Bat(54, 23));
            MapCharacters.Add(new CaveWife(80, 18));

        }
        protected override void AddTiles()
        {
            TileInfo.Add(20, new Tile(ConsoleColor.Red, (char)9618));// add new tiles
            TileInfo.Add(21, new Tile(ConsoleColor.Red, '?'));
            TileInfo[2].Color = ConsoleColor.Red;
            TileInfo[2].CharacterRepresentation = (char)9618;
            TileInfo.Add(1504, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(1526, new Tile(ExcaliburSword.Color, ExcaliburSword.CharacterRepresentation));

        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {

                case 1504://triggers to go to map mountain
                    Game.newMap = new MapMountain(1);
                    Game.CheckSpace = typeof(MapMountain).GetMethod("CheckSpace");
                    break;
                case 1526:
                    Game.AddItem(ExcaliburSword);
                    MapSpace[8][26] = 20;
                    break;
                
            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 38, 48 };//start position in cave
                    break;
                
            }
        }
    }
}

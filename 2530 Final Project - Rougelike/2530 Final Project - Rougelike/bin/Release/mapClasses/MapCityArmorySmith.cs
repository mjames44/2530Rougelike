using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class MapCityArmorySmith : MapCityMain
    {
        HealingPotion healthPot = new HealingPotion();
        Rapier rapier = new Rapier();
        WoodenHelmet helmet = new WoodenHelmet();

        public MapCityArmorySmith(int ep)
            : base(ep)
        {
            FileName = "mapCityArmorySmith.csv";

            ReadMap();
            base.AddTiles();
            AddCharacters();
            StandableTiles.AddRange(new List<int> { 511, 512 ,521,522,523,524});

            if (Game.PlayerTalkedToKing == true)
            {
                MapSpace[14][57] = 100;
                MapSpace[17][44] = 100;
            }
        }

        private void AddCharacters()
        {
            MapCharacters = new List<Character>();

            MapCharacters.Add(new FemaleVillager(46, 25, "Kristin"));
            MapCharacters.Add(new MaleVillager(57, 21, "Ryan"));
        }

        protected override void AddTiles()
        {
            TileInfo.Add(511, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(512, new Tile(ConsoleColor.White, '.'));
            TileInfo.Add(521, new Tile(rapier.Color, rapier.CharacterRepresentation));
            TileInfo.Add(522, new Tile(helmet.Color, helmet.CharacterRepresentation));
            TileInfo.Add(523, new Tile(healthPot.Color, healthPot.CharacterRepresentation));
            TileInfo.Add(524, new Tile(healthPot.Color, healthPot.CharacterRepresentation));
        }

        public override void CheckSpace(int mapValue)
        {
            switch (mapValue)
            {
                case 511:
                    Game.newMap = new MapCityMain(3);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
                case 512:
                    Game.newMap = new MapCityMain(4);
                    Game.CheckSpace = typeof(MapCityMain).GetMethod("CheckSpace");
                    break;
                case 521:
                    MapSpace[14][47] = 0;
                    Game.AddItem(rapier);
                    break;
                case 522:
                    MapSpace[10][57] = 0;
                    Game.AddItem(helmet);
                    break;
                case 523:
                    MapSpace[15][48] = 0;
                    Game.AddItem(healthPot);
                    break;
                case 524:
                    MapSpace[10][58] = 0;
                    Game.AddItem(healthPot);
                    break;

            }
        }

        protected override void SetStartingPosition(int entryPoint)
        {
            switch (entryPoint)
            {
                case 0:
                    StartingPosition = new int[] { 29, 43 };
                    break;
                case 1:
                    StartingPosition = new int[] { 29, 57 };
                    break;
            }
        }
    }
}

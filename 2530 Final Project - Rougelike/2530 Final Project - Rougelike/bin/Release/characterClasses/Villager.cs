using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Villager : NonPlayerCharacter, NonPlayer
    {
        public Villager(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'V';
            Color = ConsoleColor.Blue;
        }

        public int HP { get; set; }
    }
}

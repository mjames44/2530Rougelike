using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Horse : NonPlayerCharacter, NonPlayer
    {
        public Horse(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'H';
            Name = "Horse";
            Color = ConsoleColor.Gray;

            SpeechArray = new string[] { "Neigh!", "*Stomps foot*" };
        }

        public int HP { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Goat : NonPlayerCharacter, NonPlayer
    {
        public Goat(int x, int y) : base(x,y)
        {
            CharacterRepresentation = 'g';
            Name = "Goat";
            Color = ConsoleColor.White;

            SpeechArray = new string[]{"Baaa!", "Maa maa!"};
        }

        public int HP { get; set; }

    }
}

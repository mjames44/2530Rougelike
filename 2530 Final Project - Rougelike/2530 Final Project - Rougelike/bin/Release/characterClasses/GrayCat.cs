using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class GrayCat : NonPlayerCharacter, NonPlayer
    {
        public GrayCat(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'm';
            Name = "Gray Cat";
            Color = ConsoleColor.Gray;

            SpeechArray = new string[] { "Meow!", "Mew!", "Purrrrrr...." };
        }

        public int HP { get; set; }
    }
}

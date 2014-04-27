using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class BrownCat : NonPlayerCharacter, NonPlayer
    {
        public BrownCat(int x, int y) : base(x,y)
        {
            CharacterRepresentation = 'h';
            Name = "Brown Cat";
            Color = ConsoleColor.DarkYellow;

            SpeechArray = new string[]{"Meow!", "Mew!","MEEEOW!"};
        }

        public int HP { get; set; }
    }
}

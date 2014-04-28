using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Dog : NonPlayerCharacter, NonPlayer
    {
        public Dog(int x, int y) : base(x,y)
        {
            CharacterRepresentation = 'd';
            Name = "Dog";
            Color = ConsoleColor.DarkYellow;

            SpeechArray = new string[]{"Woof Woof!", "Arf!","*Pant* *Pant*"};
        }

        public int HP { get; set; }
    }
}

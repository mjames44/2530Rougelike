using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Chicken : NonPlayerCharacter, NonPlayer
    {
        public Chicken(int x, int y) : base(x,y)
        {
            CharacterRepresentation = 'm';
            Name = "Chicken";
            Color = ConsoleColor.White;

            SpeechArray = new string[]{"Cluck"};
        }

        public int HP { get; set; }
    }
}

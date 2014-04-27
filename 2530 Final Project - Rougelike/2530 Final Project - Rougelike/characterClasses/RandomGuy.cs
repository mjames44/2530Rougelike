using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class RandomGuy : NonPlayerCharacter, NonPlayer
    {
        public RandomGuy(int x, int y) : base(x,y)
        {
            CharacterRepresentation = 'g';
            Name = "bob";
            Color = ConsoleColor.White;

            SpeechArray = new string[]{"Hey!", "Hi!","Hello!"};
        }

        public int HP { get; set; }
    }
}

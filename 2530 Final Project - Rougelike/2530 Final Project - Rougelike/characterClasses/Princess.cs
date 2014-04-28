using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Princess : NonPlayerCharacter, NonPlayer
    {
        public Princess(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'P';
            Name = "Princess Buttercup";
            Color = ConsoleColor.White;

            SpeechArray = new string[] { "My Hero!", "You deserve a kiss!", "Oops! I didn't mean to turn you into a Toad!" };
        }

        public int HP { get; set; }
    }
}

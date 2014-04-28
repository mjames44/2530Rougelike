using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Guard : NonPlayerCharacter, NonPlayer
    {
        public Guard(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'g';
            Name = "Guard";
            Color = ConsoleColor.DarkBlue;

            SpeechArray = new string[]{"Hey!", "Hi!","Hello!"};
        }

        public int HP { get; set; }

        public override void Move(int[] space)
        {
        }
    }
}

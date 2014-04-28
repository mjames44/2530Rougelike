using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Advisor : NonPlayerCharacter, NonPlayer
    {
        public Advisor(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'R';
            Name = "Royal Advisor Stephen";

            Color = ConsoleColor.Gray;

            SpeechArray = new string[]
            {
                "Oh, the poor princess...",
                "I've watched over her ever since she was a girl, whatever can I do...",
                "You're good to go after her.",
                "Start by going east out of town, to the forest.  \nFrom their, head north to the cave.",
                "The old man there can help you."
            };

        }

        public override void Move(int[] space)
        {
        }

        public int HP
        {
            get;
            set;
        }
    }
}

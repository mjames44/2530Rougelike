using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class GuardCaptain : NonPlayerCharacter, NonPlayer
    {
        public GuardCaptain(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'C';
            Name = "Guard Captain Dirk";

            Color = ConsoleColor.DarkBlue;

            SpeechArray = new string[]
            {
                "The Kingdom needs help, and you seem like you're just the one for the job.",
                "See my lieutenant ,Jared,  in the Barracks. He might be able to help you.",
                "Also, talk to Kristin and Ryan in the Armory and Smithy.",
                "They're an odd pair, but they should be able to help you too.",
                "Good luck!"
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

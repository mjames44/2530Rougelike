using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class King : NonPlayerCharacter, NonPlayer
    {
        public King(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'K';
            Name = "King Patrick";

            Color = ConsoleColor.DarkMagenta;

        }

        public override void Move(int[] space)
        {
        }

        public override void Talk()
        {
            SpeechArray = new string[]
            {
                "By now you've heard our sad news.",
                "Our Princess has been taken from us, \n"
            + "carried far away to the Dark Castle",
                "We desparately need your help, if you're willing.",
                "Talk to the Captain of my Guard and my Advisor to find out more.",
                "Thank you, and Good luck!"
            };

            if (talkCount < SpeechArray.Length)
                Game.Message = String.Format("{0}: {1}", Name, SpeechArray[talkCount++ % SpeechArray.Length]);
            else
                Game.Message = String.Format("{0}: {1}", Name, SpeechArray[4]);

            if (talkCount == 1)
            {
                Game.PlayerTalkedToKing = true;
            }

            Game.ShowMessage(1);
        }

        public int HP
        {
            get;
            set;
        }
    }
}

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

        }

        public override void Talk()
        {
            SpeechArray = new string[] { 
                "My Hero!", 
                "You deserve a kiss!",
                "Oops! I didn't mean to turn you into a Toad!\n\n" +
            "You saved the Princess! \n (and I'm sure you'll get better...)"};

            Game.Message = String.Format("{0}: {1}", Name, SpeechArray[talkCount % SpeechArray.Length]);

            Game.ShowMessage(0);

            if (talkCount == 2)
            {
                Game.Done = true;
            }

            talkCount++;
        }

        public int HP { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class GhostGuy : NonPlayerCharacter, NonPlayer
    {
        
        public GhostGuy(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'g';
            Name = "Old Man";
            Color = ConsoleColor.Gray;
            talkCount = 0;
            SpeechArray = new string[] { "It is Dangerous to go alone take this. *gives Stevo a Corndog*", "Good Luck" };
        }

        public override void Talk()
        {
            if (talkCount == 0)
            {
                Game.Message = String.Format("{0}: {1}", Name, SpeechArray[0]);
                Game.ShowMessage(0);
                Game.AddItem(new CornDog());
            }
            else
            {
                Game.Message = String.Format("{0}: {1}", Name, SpeechArray[1]);
                Game.ShowMessage(0);
            }
            talkCount++;
        }

        public override void Move(int[] space)
        {
            
        }

        public int HP { get; set; }
    }
}

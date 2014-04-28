using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class BarracksCaptain : NonPlayerCharacter, NonPlayer
    {
        public BarracksCaptain(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'C';
            Name = "Guard Captain Jared";

            Color = ConsoleColor.DarkBlue;

            SpeechArray = new string[] { "Hey!", "Hi!", "Hello!" };

        }

        public override void Move(int[] space)
        {
        }

        public override void Talk()
        {
            SpeechArray = new string[]
            {
                "The princess has been captured.",
                "We have to defend the castle, we need a hero.",
                "You look strong, you might just fit!",
                "",
                "Good luck!"
            };

            if (talkCount < 4)
                Game.Message = String.Format("{0}: {1}", Name, SpeechArray[talkCount++ % SpeechArray.Length]);
            else
                Game.Message = String.Format("{0}: {1}", Name, SpeechArray[4]);

            if (talkCount == 3 && Game.PlayerTalkedToKing)
            {
                Game.AddItem(new HealingPotion());
                Game.AddItem(new HealingPotion());

                Game.Message = "It's dangerous on the road, take these.\n\n" +
                    "The captain gives you two healing potions.*";
            }

            Game.ShowMessage(0);
        }

        public int HP
        {
            get;
            set;
        }
    }
}

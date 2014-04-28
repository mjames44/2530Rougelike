using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class TowerSpirit : NonPlayerCharacter, NonPlayer
    {
        public TowerSpirit(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'S';
            Name = "Scary";
            Color = ConsoleColor.White;

            SpeechArray = new string[]{"Go Away!!", "You will die if you touch me again!","Ok, Ok, I'll tell you a secret.You can get to the dungeon through a secret passage outside at the back of the castle. Now leave me alone!"};
        }

        public int HP { get; set; }
    }
}

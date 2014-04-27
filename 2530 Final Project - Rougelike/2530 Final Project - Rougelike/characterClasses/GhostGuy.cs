using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike.characterClasses
{
    class GhostGuy : NonPlayerCharacter, NonPlayer
    {
        public GhostGuy(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'g';
            Name = "Old Man";
            Color = ConsoleColor.Gray;

            SpeechArray = new string[] { "It is Dangerous to go alone take this. *gives Stevo a Corndog*", "Good Luck" };
        }
        
        

        public int HP { get; set; }
    }
}

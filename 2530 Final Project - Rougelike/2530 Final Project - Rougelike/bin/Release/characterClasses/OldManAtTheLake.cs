using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class OldManAtTheLake : NonPlayerCharacter, NonPlayer
    {

        public OldManAtTheLake(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'F';
            Name = "Old Man Franks";
            Color = ConsoleColor.DarkGreen;
            talkCount = 0;
            SpeechArray = new string[] { 
                "You will will need to travel to the Dark Castle so find what you seek.", 
                "Head South through the forest.",
                "The Castle is due south of here.",
                "The corndog is more powerful than it apears.",
                "Don't eat the fruitcake." };
        }

        public override void Move(int[] space)
        {

        }

        public int HP { get; set; }

    }
    
}

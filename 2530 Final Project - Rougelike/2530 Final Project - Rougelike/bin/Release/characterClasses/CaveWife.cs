using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class CaveWife : NonPlayerCharacter, NonPlayer
    {

        public CaveWife(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'L';
            Name = "Lulabell";
            Color = ConsoleColor.Magenta;
            talkCount = 0;
            SpeechArray = new string[] { 
                "My husband is not here.    ", 
                "I sent him to the lake to bring us back some fish for dinner.         ", 
                "He has a secret hiding spot where he keeps his sword. \nIt is in the North West part of the cave." };
        }

        public override void Move(int[] space)
        {

        }

        public int HP { get; set; }

    }
    
}

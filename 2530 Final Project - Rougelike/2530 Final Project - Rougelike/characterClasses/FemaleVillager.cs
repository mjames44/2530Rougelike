using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class FemaleVillager : Villager, NonPlayer
    {
        public FemaleVillager(int x, int y, string name)
            : base(x, y)
        {
            CharacterRepresentation = name[0];
            Name = name;

            SpeechArray = new string[]{
                "Hello.", 
                "Oh our poor Princess.",
                "Welcome to our town."};
        }

    }
}

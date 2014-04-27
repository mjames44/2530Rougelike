using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class FemaleVillagerShauna : Villager, NonPlayer
    {
        public FemaleVillagerShauna(int x, int y)
            : base(x, y)
        {
            Name = "Shauna";

            SpeechArray = new string[]{
                "Hello.", 
                "Oh our poor Princess.",
                "Welcome to our town."};
        }

        public int HP { get; set; }
    }
}

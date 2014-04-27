using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Child : Villager, NonPlayer
    {
        public Child(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'c';
            Name = "Child";

            SpeechArray = new string[]{
                "Hey!",
                "Hi!",
                "Save the Princess!"};
        }

        public int HP { get; set; }
    }
}

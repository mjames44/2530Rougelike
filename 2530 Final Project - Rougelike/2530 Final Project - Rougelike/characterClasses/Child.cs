using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Child : Villager, NonPlayer
    {
        public Child(int x, int y, string name)
            : base(x, y)
        {
            CharacterRepresentation = name[0];
            Name = name;

            SpeechArray = new string[]{
                "Hey!",
                "Hi!",
                "Save the Princess!"};
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class MaleVillager : Villager, NonPlayer
    {
        public MaleVillager(int x, int y, string name)
            : base(x, y)
        {
            CharacterRepresentation = name[0];
            Name = name;
            Color = ConsoleColor.Blue;

            SpeechArray = new string[]{
                "Hello!",
                "Did you hear about the Princess?",
                "Terrible news that."};
        }

    }
}

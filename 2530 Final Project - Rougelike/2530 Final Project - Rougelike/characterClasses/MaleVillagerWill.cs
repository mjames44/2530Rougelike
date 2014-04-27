using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class MaleVillagerWill : Villager, NonPlayer
    {
        public MaleVillagerWill(int x, int y)
            : base(x, y)
        {
            CharacterRepresentation = 'g';
            Name = "Will";
            Color = ConsoleColor.White;

            SpeechArray = new string[]{
                "Hello!",
                "Did you hear about the Princess?",
                "Terrible news that."};
        }

        public int HP { get; set; }
    }
}

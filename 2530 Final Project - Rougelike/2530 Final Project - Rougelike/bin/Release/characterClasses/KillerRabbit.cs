using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class KillerRabbit : Monster, NonPlayer
    {
        public KillerRabbit(int x, int y)
            : base(x, y)
        {
            HP = 65;
            XP = 60;

            CharacterRepresentation = 'R';
            Name = "Killer Rabbit";
            Color = ConsoleColor.White;
            Attack = 25;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 23;
        }

        public override void DropItem()
        {
        }
    }
}

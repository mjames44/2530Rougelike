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
            HP = 45;
            XP = 60;

            CharacterRepresentation = 'R';
            Name = "Killer Rabbit";
            Color = ConsoleColor.White;
            Attack = 11;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 13;
        }

        public void Move()
        {
        }

        public override Character Interact(Character otherChar)
        {
            return this;
        }

        public override void DropItem()
        {
        }
    }
}

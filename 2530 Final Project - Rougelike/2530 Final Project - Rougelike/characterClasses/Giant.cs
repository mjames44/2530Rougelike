using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Giant : Monster, NonPlayer
    {   
        public Giant(int x, int y) : base(x,y)
        {
            HP = 50;
            XP = 50;

            CharacterRepresentation = 'G';
            Name = "Giant";
            Color = ConsoleColor.Magenta;
            Attack = 9;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 10;
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

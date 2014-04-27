using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Ghost : Monster, NonPlayer
    {   
        public Ghost(int x, int y) : base(x,y)
        {
            HP = 15;
            XP = 20;

            CharacterRepresentation = 'G';
            Name = "Ghost";
            Color = ConsoleColor.White;
            Attack = 5;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 4;
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

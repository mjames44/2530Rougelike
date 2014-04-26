using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Orc : Monster, NonPlayer
    {   
        public Orc(int x, int y) : base(x,y)
        {
            HP = 35;
            XP = 40;

            CharacterRepresentation = 'O';
            Name = "Orc";
            Color = ConsoleColor.DarkGray;
            Attack = 6;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 7;
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

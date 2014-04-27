using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Bat : Monster, NonPlayer
    {   
        public Bat(int x, int y) : base(x,y)
        {
            HP = 10;
            XP = 10;

            CharacterRepresentation = 'B';
            Name = "Bat";
            Color = ConsoleColor.DarkCyan;
            Attack = 3;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 3;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Troll : Monster, NonPlayer
    {   
        public Troll(int x, int y) : base(x,y)
        {
            HP = 35;
            XP = 30;

            CharacterRepresentation = 'T';
            Name = "Troll";
            Color = ConsoleColor.Gray;
            Attack = 4;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 9;
        }

        public override void DropItem()
        {
        }
    }
}


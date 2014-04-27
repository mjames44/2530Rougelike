using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Goblin : Monster, NonPlayer
    {   
        public Goblin(int x, int y) : base(x,y)
        {
            HP = 15;
            XP = 10;

            CharacterRepresentation = 'G';
            Name = "Goblin";
            Color = ConsoleColor.Green;
            Attack = 2;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 3;
        }
        public override void DropItem()
        {
        }
    }
}

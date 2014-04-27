using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class GiantLeech : Monster, NonPlayer
    {   
        public GiantLeech(int x, int y) : base(x,y)

        {
            HP = 30;
            XP = 60;

            CharacterRepresentation = 'L';
            Name = "Giant Leech";
            Color = ConsoleColor.Cyan;
            Attack = 9;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 12;
        }
        public override void DropItem()
        {
        }
    }
}

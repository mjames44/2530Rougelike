using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Dragon : Monster, NonPlayer
    {
        public Dragon(int x, int y)
            : base(x, y)
        {
            HP = 180;
            XP = 90;

            CharacterRepresentation = 'D';
            Name = "Dragon";
            Color = ConsoleColor.Cyan;
            Attack = 40;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 40;
        }

        public override void DropItem()
        {
        }
    }
}

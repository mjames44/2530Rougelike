using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class DarkDwarf : Monster, NonPlayer
    {   
        public DarkDwarf(int x, int y) : base(x,y)
        {
            HP = 20;
            XP = 40;

            CharacterRepresentation = 'D';
            Name = "Dark Dwarf";
            Color = ConsoleColor.DarkYellow;
            Attack = 3;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 8;
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

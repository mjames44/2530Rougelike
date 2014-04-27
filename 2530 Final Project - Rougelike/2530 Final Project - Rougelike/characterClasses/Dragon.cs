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
            HP = 80;
            XP = 90;

            CharacterRepresentation = 'D';
            Name = "Dragon";
            Color = ConsoleColor.Cyan;
            Attack = 20;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 20;
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

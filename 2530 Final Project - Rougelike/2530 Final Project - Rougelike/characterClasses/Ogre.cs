using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Ogre : Monster, NonPlayer
    {   
        public Ogre(int x, int y) : base(x,y)
        {
            HP = 35;
            XP = 55;

            CharacterRepresentation = 'O';
            Name = "Ogre";
            Color = ConsoleColor.DarkGreen;
            Attack = 7;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 8;
        }

        public override void DropItem()
        {
        }
    }
}

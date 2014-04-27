using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Ghost : Monster, NonPlayer
<<<<<<< HEAD
    {
        public Ghost(int x, int y)
            : base(x, y)
=======
    {   
        public Ghost(int x, int y) : base(x,y)
>>>>>>> 0b72d760e46a2a46b5e79292f0464779719c02c8
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

        public override void DropItem()
        {
        }
    }
}

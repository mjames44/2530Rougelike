using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class GiantLeech : Monster, NonPlayer
<<<<<<< HEAD
    {
        public GiantLeech(int x, int y)
            : base(x, y)
=======
    {   
        public GiantLeech(int x, int y) : base(x,y)
>>>>>>> 0b72d760e46a2a46b5e79292f0464779719c02c8
        {
            HP = 30;
            XP = 60;

            CharacterRepresentation = 'L';
            Name = "Giant Leech";
            Color = ConsoleColor.DarkBlue;
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

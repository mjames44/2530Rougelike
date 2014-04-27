using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Demon : Monster, NonPlayer
<<<<<<< HEAD
    {
        public Demon(int x, int y)
            : base(x, y)
=======
    {   
        public Demon(int x, int y) : base(x,y)
>>>>>>> 0b72d760e46a2a46b5e79292f0464779719c02c8
        {
            HP = 50;
            XP = 70;

            CharacterRepresentation = 'D';
            Name = "Demon";
            Color = ConsoleColor.DarkRed;
            Attack = 15;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 20;
        }
        public override void DropItem()
        {
        }
    }
}

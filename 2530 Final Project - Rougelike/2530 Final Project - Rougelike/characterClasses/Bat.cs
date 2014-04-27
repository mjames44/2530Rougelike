using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Bat : Monster, NonPlayer
<<<<<<< HEAD
    {
        public Bat(int x, int y)
            : base(x, y)
=======
    {   
        public Bat(int x, int y) : base(x,y)
>>>>>>> 0b72d760e46a2a46b5e79292f0464779719c02c8
        {
            HP = 10;
            XP = 10;

            CharacterRepresentation = 'B';
            Name = "Bat";
            Color = ConsoleColor.DarkCyan;
            Attack = 3;
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

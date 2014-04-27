using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Wraith : Monster, NonPlayer
<<<<<<< HEAD
    {
        public Wraith(int x, int y)
            : base(x, y)
=======
    {   
        public Wraith(int x, int y) : base(x,y)
>>>>>>> 0b72d760e46a2a46b5e79292f0464779719c02c8
        {
            HP = 40;
            XP = 50;

            CharacterRepresentation = 'W';
            Name = "Wraith";
            Color = ConsoleColor.DarkYellow;
            Attack = 12;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 15;
        }

        public override void DropItem()
        {
        }
    }
}

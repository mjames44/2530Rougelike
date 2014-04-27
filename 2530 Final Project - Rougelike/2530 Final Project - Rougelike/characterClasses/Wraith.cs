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

=======
    {   
>>>>>>> 4800e6ca1e9baa56364ae0bb1c4caadd2aa6c954
        public Wraith(int x, int y) : base(x,y)

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

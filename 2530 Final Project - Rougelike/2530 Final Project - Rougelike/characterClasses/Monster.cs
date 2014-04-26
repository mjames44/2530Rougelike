using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    abstract class Monster : Character, NonPlayer
    {
        public int XP { get; protected set; }

        public Monster(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int HP { get; set; }

        public void Move() { }
        public abstract void DropItem();
    }
}

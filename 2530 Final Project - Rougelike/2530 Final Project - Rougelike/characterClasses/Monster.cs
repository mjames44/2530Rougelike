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

        public Monster(int x, int y, char cr, string name, ConsoleColor color,
            int atk, int def, int arm, int min, int max)
            : base(cr, name, color,
                atk, def, arm, min, max)
        {
            X = x;
            Y = y;
        }

        public int HP { get; set; }

        public void Move() { }
        public abstract void DropItem();
    }
}

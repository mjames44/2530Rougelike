using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class HealingPotion : Item
    {
        public HealingPotion() : base("Healing Potion", -10, 0, -10, 20,'p', ConsoleColor.Red) {}
    }
}

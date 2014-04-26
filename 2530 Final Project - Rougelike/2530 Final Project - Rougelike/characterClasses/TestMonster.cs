using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class TestMonster : Monster, NonPlayer
    {
        public TestMonster(int x, int y) : base (x,y,'m',"Test Monster", ConsoleColor.Green, 1,1,1,1,1) 
        {
            HP = 20;
            XP = 500;
        }

        public void Move()
        {
        }

        public override Character Interact(Character otherChar)
        {
            return this;
        }

        public override void DropItem()
        {
        }
    }
}

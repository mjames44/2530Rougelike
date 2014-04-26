using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class TestMonster : Monster, NonPlayer
    {
        char charRep = 'm';
        string name = "Test Monster";
        ConsoleColor color = ConsoleColor.Green;
        int atk = 1; 
        int def = 1; 
        int arm = 1;
        int min = 1;
        int max = 1;
        
        public TestMonster(int x, int y) : base(x,y)
        {
            HP = 20;
            XP = 500;

            CharacterRepresentation = 'm';
            Name = "Test Monster";
            Color = ConsoleColor.Green;
            Attack = 1;
            Defense = 1;
            Armor = 1;
            MinDamage = 1;
            MaxDamage = 1;
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

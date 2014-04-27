﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Demon : Monster, NonPlayer
    {   
        public Demon(int x, int y) : base(x,y)
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

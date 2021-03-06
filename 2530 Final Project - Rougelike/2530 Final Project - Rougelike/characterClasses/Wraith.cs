﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Wraith : Monster, NonPlayer
    {
        public Wraith(int x, int y) : base(x,y)

        {
            HP = 80;
            XP = 50;

            CharacterRepresentation = 'W';
            Name = "Wraith";
            Color = ConsoleColor.DarkYellow;
            Attack = 22;
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

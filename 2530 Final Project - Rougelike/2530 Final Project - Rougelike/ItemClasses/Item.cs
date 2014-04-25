using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Item
    {
        public int MinDamage { get; protected set; }
        public int MaxDamage { get; protected set; }
        public char CharacterRepresentation { get; protected set; }
        public String Name { get; protected set; }
        public int DefenseModifier { get; protected set; }
        public int HealthModifier { get; protected set; }
        public ConsoleColor Color { get; protected set; }

        public Item(String name, int min, int max, int defenseMod, int healthMod, char cr, ConsoleColor clr)
        {
            Name = name;
            MinDamage = min;
            MaxDamage = max;
            DefenseModifier = defenseMod;
            HealthModifier = healthMod;
            CharacterRepresentation = cr;
            Color = clr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike.ItemClasses
{
    class Item
    {
        String Name { get; private set; }
        int AttackModifier { get; private set; }
        int DeffenceModifier { get; private set; }
        int HealthModifier { get; private set; }

        public Item(String name, int attackMod, int deffenceMod, int healthMod)
        {
            Name = name;
            AttackModifier = attackMod;
            DeffenceModifier = deffenceMod;
            HealthModifier = healthMod;
        }
    }
}

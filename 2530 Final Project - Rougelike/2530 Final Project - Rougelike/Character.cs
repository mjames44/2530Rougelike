using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Character
    {
        public int X { get; set; }
        public int Y { get; set; }

        // Don't want to leave this public set, need to figure out why it's complaining
        public char CharacterRepresentation { get; set; }
    }
}

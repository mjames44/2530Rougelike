using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Tile
    {
        public ConsoleColor Color { get; set; }
        public char CharacterRepresentation { get; set; }

        public Tile (ConsoleColor color, char cr )
        {
            Color = color;
            CharacterRepresentation = cr;
        }
    }
}

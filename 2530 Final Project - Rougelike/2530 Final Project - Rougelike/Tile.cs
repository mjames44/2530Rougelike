using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    struct Tile
    {
        public ConsoleColor Color { get; set; }
        public char CharacterRepresentation { get; set; }

        public Tile (ConsoleColor color, char cr ) : this()
        {
            Color = color;
            CharacterRepresentation = cr;
        }
    }
}

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
        public int PreviousX { get; set; }
        public int PreviousY { get; set; }
        public int HP { get; set; }


        public Character()
        { 
           
        }

        // Don't want to leave this public set, need to figure out why it's complaining
        public char CharacterRepresentation { get; protected set; }

        public int[] Position
        {
            get
            {
                return new int[2] { Y, X };
            }
            set
            {
                X = value[0];
                Y = value[1];
            }
        }

        public int[] PreviousPosition
        {
            get
            {
                return new int[2] { PreviousY, PreviousX };
            }
            set
            {
                PreviousX = value[1];
                PreviousY = value[0];
            }
        }
    }
}

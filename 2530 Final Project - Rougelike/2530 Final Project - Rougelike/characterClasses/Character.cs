﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    abstract class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int PreviousX { get; set; }
        public int PreviousY { get; set; }

        public string Name { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Armor { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Character()
        { 
           
        }

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

        public abstract void SpaceOccupied();
    }
}

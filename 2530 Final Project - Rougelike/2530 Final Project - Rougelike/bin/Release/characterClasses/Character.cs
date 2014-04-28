using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    abstract class Character
    {
        // Properties
        public int X { get; set; }
        public int Y { get; set; }
        public char CharacterRepresentation { get; protected set; }
        public string Name { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Armor { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public bool CharacterMoved { get; set; }
        public int PreviousX { get; set; }
        public int PreviousY { get; set; }

        public int[] Position
        {
            get
            {
                return new int[2] { Y, X };
            }
            set
            {
                X = value[1];
                Y = value[0];
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

        // Constructor
        public Character()
        {
            CharacterMoved = true;
        }

        // Methods

        protected int GetDamage()
        {
            Random rand = new Random();

            if (MaxDamage - MinDamage != 0)
                return (int)(rand.Next() % (MaxDamage - MinDamage)) - (0 - MinDamage);
            else
                return 0;
        }

        public virtual void Move(int[] space)
        {
            int[] storageArray = Position;

            if (space != Position)
            {
                Position = space;
                CharacterMoved = true;
                PreviousPosition = storageArray;
            }
            else
                CharacterMoved = false;
        }

        internal int[] NextSpace(int[][] mapSpace, List<int> standableTiles, int dir)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            int moveDirection = dir % 8;

            switch (moveDirection)
            {
                case 0:
                    if (standableTiles.Contains(mapSpace[Y - 1][X]))
                        return new int[] { Y - 1, X };
                    break;
                case 1:
                    if (standableTiles.Contains(mapSpace[Y + 1][X]))
                        return new int[] { Y + 1, X };
                    break;
                case 2:
                    if (standableTiles.Contains(mapSpace[Y][X - 1]))
                        return new int[] { Y, X - 1 };
                    break;
                case 3:
                    if (standableTiles.Contains(mapSpace[Y][X + 1]))
                        return new int[] { Y, X + 1 };
                    break;
                case 4:
                    if (standableTiles.Contains(mapSpace[Y - 1][X - 1]))
                        return new int[] { Y - 1, X - 1 };
                    break;
                case 5:
                    if (standableTiles.Contains(mapSpace[Y + 1][X - 1]))
                        return new int[] { Y + 1, X + 1 };
                    break;
                case 6:
                    if (standableTiles.Contains(mapSpace[Y - 1][X + 1]))
                        return new int[] { Y - 1, X + 1 };
                    break;
            }

            return new int[] { Y + 1, X + 1 };

        }
    }
}

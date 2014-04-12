using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Program
    {
        static PlayerCharacter pc = new PlayerCharacter();
        static bool done;
        static int[,] playingSpace;

        static void Main(string[] args)
        {
            playingSpace = new int[10, 10];
            ConsoleKeyInfo keyPressed;

            done = false;

            #region Drawing the maze/dungeon/whatever
            drawPlayspace(playingSpace);
            #endregion

            for (int row = 0; row < playingSpace.GetLength(0); row++)
            {
                for (int col = 0; col < playingSpace.GetLength(1); col++)
                {
                    // Need to figure out which character we want to use for walls.
                    Console.Write("{0}", ((playingSpace[row, col] == 0) ? '.' : (char)166));
                }
                Console.WriteLine();
            }

            while (!done)
            {
                #region Listen for input, update character location
                #region Character
                keyPressed = Console.ReadKey();

                updateCharacterLocation(keyPressed);
                #endregion Character

                #region Other Stuff
                #endregion Other Stuff
                #endregion 

                #region Draw changes to playing space
                drawCharacter();
                #endregion
            }
        }

        #region Update Methods
        private static void updateCharacterLocation(ConsoleKeyInfo keyPressed)
        {
            switch (keyPressed.Key)
            {
                case ConsoleKey.RightArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                    moveCharcter(keyPressed.Key);
                    break;
                default: break;
            }
        }

        private static void moveCharcter(ConsoleKey key)
        {
            int[] currentLocation = new int[] { pc.X, pc.Y };

            if (key == ConsoleKey.DownArrow && playingSpace[pc.X,pc.Y+1] != 1)
                pc.Y++;
            else if (key == ConsoleKey.UpArrow && playingSpace[pc.X, pc.Y - 1] != 1)
                pc.Y--;
            else if (key == ConsoleKey.RightArrow && playingSpace[pc.X + 1, pc.Y] != 1)
                pc.X++;
            else if (key == ConsoleKey.LeftArrow && playingSpace[pc.X - 1, pc.Y] != 1)
                pc.X--;
        }
        #endregion

        #region Draw Methods
        private static void drawCharacter()
        {
            Console.SetCursorPosition(pc.X, pc.Y);

            Console.Write('@');
        }

        private static void drawPlayspace(int[,] playingSpace)
        {
            // Need to clear the console, so the character draw methods will draw correctly
            // and the character can detect the walls.
            Console.Clear();

            int[] topBottomRow = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] middleRows = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 };

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < topBottomRow.Length; j++)
                {
                    if (i == 0 || i == 9)
                    {
                        playingSpace[i, j] = topBottomRow[j];
                    }
                    else
                    {
                        playingSpace[i, j] = middleRows[j];
                    }
                }
            }
        } 
# endregion
    }
}

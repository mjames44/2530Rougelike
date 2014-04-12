using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2530_Final_Project___Rougelike
{
    class Program
    {
        static PlayerCharacter pc;
        static List<Character> characterList;
        static bool done;
        static byte[,] mapSpace;
        static int playingSpaceLeft;
        static int playingSpaceTop;

        static void Main(string[] args)
        {
            playingSpaceLeft = 0;
            playingSpaceTop = 0;
            ConsoleKeyInfo keyPressed;
            characterList = new List<Character>();

            pc = new PlayerCharacter();
            characterList.Add(pc);

            done = false;

            #region Initial Draw
            initializePlayingSpace();
            drawPlayspace();
            #endregion

            while (!done)
            {
                #region Listen for input, update character location
                #region Character
                updateCharacterLocation(Console.ReadKey());
                #endregion Character

                #region Other Stuff
                #endregion Other Stuff
                #endregion

                //#region Draw changes to playing space
                //drawPlayspace();
                //#endregion
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
                    moveCharacter(keyPressed.Key);
                    break;
                default: break;
            }

            switch (keyPressed.KeyChar)
            {
                case '?':
                    showHelpScreen();
                    break;
            }
        }

        private static void showHelpScreen()
        {
            Console.Clear();

            Console.WriteLine("This is the help screen.");
            Console.WriteLine("press Q to return to the game");

            ConsoleKey input = ConsoleKey.A;

            do
            {
                while (Console.KeyAvailable)
                {
                    input = Console.ReadKey(false).Key;
                }
            } while (input != ConsoleKey.Q);

            drawPlayspace();
        }

        private static void moveCharacter(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow && mapSpace[pc.Y + 1, pc.X] == 0)
                pc.Y++;
            else if (key == ConsoleKey.UpArrow && mapSpace[pc.Y - 1, pc.X] == 0)
                pc.Y--;
            else if (key == ConsoleKey.RightArrow && mapSpace[pc.Y, pc.X + 1] == 0)
                pc.X++;
            else if (key == ConsoleKey.LeftArrow && mapSpace[pc.Y, pc.X - 1] == 0)
                pc.X--;

            
        }
        #endregion

        #region Draw Methods
        private static void initializePlayingSpace()
        {
            mapSpace = new byte[,] {
            {1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {1,1,1,1,1,1,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {1,1,1,1,1,1,1,0,1,1,1,0,1,2,2,2,2,2,2,2},
            {1,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2},
            {1,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2},
            {1,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2},
            {1,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2}};

        }


        private static char[,] drawCharacter(char[,] map)
        {
            foreach (Character el in characterList)
            {
                map[el.Y, el.X] = el.CharacterRepresentation;
            }

            return map;
        }

        private static void drawPlayspace()
        {
            // Need to clear the console, so the character draw methods will draw correctly
            // and the character can detect the walls.

            /* Steps
             * 1. Copy mapSpace into playSpace
             * 2. Update playSpace with Character info
             * 3. Print playSpace.
             * */

            #region Step 1

            char[,] playingSpace = new char[mapSpace.GetLength(0), mapSpace.GetLength(1)];

            for (int row = 0; row < mapSpace.GetLength(0); row++)
            {
                for (int col = 0; col < mapSpace.GetLength(1); col++)
                {
                    switch (mapSpace[row, col])
                    {
                        case 0:
                            playingSpace[row, col] = '.';
                            break;
                        case 1:
                            playingSpace[row, col] = (char)166;
                            break;
                        case 2:
                            playingSpace[row, col] = ' ';
                            break;
                    }
                }
            }

            #endregion

            #region Step 2
            playingSpace = drawCharacter(playingSpace);
            #endregion

            #region Step 3
            Console.Clear();
            Console.SetCursorPosition(playingSpaceLeft, playingSpaceTop);

            StringBuilder map = new StringBuilder();

            for (int row = 0; row < playingSpace.GetLength(0); row++)
            {
                for (int col = 0; col < playingSpace.GetLength(1); col++)
                {
                    // Need to figure out which character we want to use for walls.
                    map.Append(playingSpace[row, col]);
                }
                map.Append('\n');
            }

            Console.WriteLine("The last position was: {0},{1}", pc.X, pc.Y);

            Console.Write(map.ToString());
            #endregion
        }
        # endregion
    }
}

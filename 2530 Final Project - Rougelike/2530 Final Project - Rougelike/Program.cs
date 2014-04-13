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
        static int[,] mapSpace;
        static int playingSpaceLeft;
        static int playingSpaceTop;
        static List<int> standableTiles;
        static string message;
        static string oldMessage;
        static int messageCounter;
        static int maxMessageCounterValue;

        static void Main(string[] args)
        {
            initializeGame();

            standableTiles = new List<int> { 0, 3, 4, 100 };
            
            // Initial Draw
            drawMap();

            while (!done)
            {
                #region Listen for input, update character updates, execute all other updates
                #region Character
                keyboardInput(Console.ReadKey(false));
                #endregion Character

                #region Other Stuff
                #endregion Other Stuff
                #endregion
            }

            
        }

        private static void initializeGame()
        {
            playingSpaceLeft = 0;
            playingSpaceTop = 0;
            
            characterList = new List<Character>();
            pc = new PlayerCharacter();
            characterList.Add(pc);
            done = false;

           initializeMap();
        }

        #region Update Methods
        private static void keyboardInput(ConsoleKeyInfo keyPressed)
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
                case 'o' :
                    tryOpenDoor();
                    break;
                case 'Q' :
                    done = true;
                    break;
            }
        }

        private static void tryOpenDoor()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Door in which direction?");

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.UpArrow :
                    if (mapSpace[pc.Y - 1, pc.X] >= 101 && mapSpace[pc.Y,pc.X] <= 300)
                        openDoor(1);
                    break;
                case ConsoleKey.DownArrow:
                    if (mapSpace[pc.Y + 1, pc.X] >= 101 && mapSpace[pc.Y, pc.X] <= 300)
                        openDoor(2);
                    break;
                case ConsoleKey.LeftArrow:
                    if (mapSpace[pc.Y, pc.X - 1] >= 101 && mapSpace[pc.Y, pc.X] <= 300)
                        openDoor(3);
                    break;
                case ConsoleKey.RightArrow:
                    if (mapSpace[pc.Y, pc.X + 1] >= 101 && mapSpace[pc.Y, pc.X] <= 300)
                        openDoor(4);
                    break;
                    
            }
        }

        private static void openDoor(int doorDirection)
        {
            Random rand = new Random();
            int pickScore = rand.Next(101);

            switch(doorDirection)
            {
                case 1 :
                    if (pickScore + pc.LockPickSkill >= mapSpace[pc.Y - 1, pc.X])
                    {
                        mapSpace[pc.Y - 1, pc.X] = 100;
                    }

                    message = String.Format("Door Direction: {0} Score:{1} MapValue: {2}", "up", pickScore + pc.LockPickSkill, mapSpace[pc.Y - 1, pc.X]);
                    break;
                case 2:
                    if (pickScore + pc.LockPickSkill >= mapSpace[pc.Y + 1, pc.X])
                    {
                        mapSpace[pc.Y + 1, pc.X] = 100;
                    }

                    message = String.Format("Door Direction: {0} Score:{1} MapValue: {2}", "down", pickScore + pc.LockPickSkill, mapSpace[pc.Y + 1, pc.X]);
                    break;
                case 3:
                    if (pickScore + pc.LockPickSkill >= mapSpace[pc.Y, pc.X - 1])
                    {
                        mapSpace[pc.Y, pc.X - 1] = 100;
                    }

                    message = String.Format("Door Direction: {0} Score:{1} MapValue: {2}", "left", pickScore + pc.LockPickSkill, mapSpace[pc.Y, pc.X - 1]);
                    break;
                case 4:
                    if (pickScore + pc.LockPickSkill >= mapSpace[pc.Y, pc.X + 1])
                    {
                        mapSpace[pc.Y, pc.X + 1] = 100;
                    }
                    message = String.Format("Door Direction: {0} Score:{1} MapValue: {2}", "right", pickScore + pc.LockPickSkill, mapSpace[pc.Y, pc.X + 1]);
                    break;
            }

            drawMap();
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

            drawMap();
        }

        private static void moveCharacter(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow && canMoveHere(mapSpace[pc.Y + 1, pc.X]))
                pc.Y++;
            else if (key == ConsoleKey.UpArrow && canMoveHere(mapSpace[pc.Y - 1, pc.X]))
                pc.Y--;
            else if (key == ConsoleKey.RightArrow && canMoveHere(mapSpace[pc.Y, pc.X + 1]))
                pc.X++;
            else if (key == ConsoleKey.LeftArrow && canMoveHere(mapSpace[pc.Y, pc.X - 1]))
                pc.X--;

            drawMap();
        }

        private static bool canMoveHere(int p)
        {
            foreach (int el in standableTiles)
            {
                if (p == el)
                    return true;
            }

            return false;
        }

        private static void initializeMap()
        {
            message = "This is the message";
            maxMessageCounterValue = 10;
            messageCounter = -1;

            mapSpace = new int[,] {
            {1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,3,0,4,0,0,1,2,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {1,1,1,1,1,1,1,100,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,0,1,2,1,0,1,2,2,2,2,2,2,2},
            {1,1,1,1,1,1,1,101,1,1,1,0,1,2,2,2,2,2,2,2},
            {1,3,4,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2},
            {1,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2},
            {1,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2},
            {1,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2}};

        }
        #endregion

        #region Draw Methods
        private static char[,] drawCharacter(char[,] map)
        {
            foreach (Character el in characterList)
            {
                map[el.Y, el.X] = el.CharacterRepresentation;
            }

            return map;
        }

        private static void drawMap()
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
                    // See the map rules for the meaning of each symbol

                    if (mapSpace[row,col] == 0)
                            playingSpace[row, col] = '.';
                    else if (mapSpace[row,col] == 1)
                            playingSpace[row, col] = (char)166;
                    else if (mapSpace[row,col] == 2)
                            playingSpace[row, col] = ' ';
                    else if (mapSpace[row,col] == 3)
                        playingSpace[row, col] = '>';
                    else if (mapSpace[row,col] == 4)
                        playingSpace[row, col] = '<';
                    else if (mapSpace[row,col] == 100)
                        playingSpace[row, col] = '-';
                    else if (mapSpace[row,col] >= 100 && mapSpace[row,col] <= 300)
                        playingSpace[row, col] = '+';
                }
            }

            #endregion

            #region Step 2
            playingSpace = drawCharacter(playingSpace);
            #endregion

            #region Step 3
            Console.Clear();
            Console.SetCursorPosition(playingSpaceLeft, playingSpaceTop);
            
            if (message != oldMessage)
            {
                oldMessage = message;
                Console.WriteLine("{0}\n", message);
                messageCounter = maxMessageCounterValue;
            }
            else if (messageCounter > 0)
            {
                Console.WriteLine("{0}\n", message);
                messageCounter--;
            }
            else if (messageCounter == 0)
            {
                Console.WriteLine();
                messageCounter--;
            }

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

            Console.Write(map.ToString());
            #endregion
        }
        # endregion
    }
}

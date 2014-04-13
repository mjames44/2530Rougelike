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
        static int[][] mapSpace;
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
            Console.SetWindowSize(160, 40);

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
                case 'o':
                    tryOpenDoor();
                    break;
                case 'Q':
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
                case ConsoleKey.UpArrow:
                    if (mapSpace[pc.Y - 1][pc.X] >= 101 && mapSpace[pc.Y][pc.X] <= 300)
                        openDoor(1);
                    break;
                case ConsoleKey.DownArrow:
                    if (mapSpace[pc.Y + 1][pc.X] >= 101 && mapSpace[pc.Y][pc.X] <= 300)
                        openDoor(2);
                    break;
                case ConsoleKey.LeftArrow:
                    if (mapSpace[pc.Y][pc.X - 1] >= 101 && mapSpace[pc.Y][pc.X] <= 300)
                        openDoor(3);
                    break;
                case ConsoleKey.RightArrow:
                    if (mapSpace[pc.Y][pc.X + 1] >= 101 && mapSpace[pc.Y][pc.X] <= 300)
                        openDoor(4);
                    break;

            }
        }

        private static void openDoor(int doorDirection)
        {
            Random rand = new Random();
            int pickScore = rand.Next(101);

            switch (doorDirection)
            {
                case 1:
                    if (pickScore + pc.LockPickSkill >= mapSpace[pc.Y - 1][pc.X])
                    {
                        if (mapSpace[pc.Y - 1][pc.X] < 300)
                            mapSpace[pc.Y - 1][pc.X] = 100;
                        else
                            message = "You can't pick this lock";
                    }

                    break;
                case 2:
                    if (pickScore + pc.LockPickSkill >= mapSpace[pc.Y + 1][pc.X])
                    {
                        if (mapSpace[pc.Y + 1][pc.X] < 300)
                            mapSpace[pc.Y + 1][pc.X] = 100;
                        else
                            message = "You can't pick this lock";
                    }

                    break;
                case 3:
                    if (pickScore + pc.LockPickSkill >= mapSpace[pc.Y][pc.X - 1])
                    {
                        if (mapSpace[pc.Y][pc.X - 1] < 300)
                            mapSpace[pc.Y][pc.X - 1] = 100;
                        else
                            message = "You can't pick this lock";
                    }

                    break;
                case 4:
                    if (pickScore + pc.LockPickSkill >= mapSpace[pc.Y][pc.X + 1])
                    {
                        if (mapSpace[pc.Y][pc.X + 1] < 300)
                            mapSpace[pc.Y][pc.X + 1] = 100;
                        else
                            message = "You can't pick this lock";
                    }

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
            if (key == ConsoleKey.DownArrow && canMoveHere(mapSpace[pc.Y + 1][pc.X]))
                pc.Y++;
            else if (key == ConsoleKey.UpArrow && canMoveHere(mapSpace[pc.Y - 1][pc.X]))
                pc.Y--;
            else if (key == ConsoleKey.RightArrow && canMoveHere(mapSpace[pc.Y][pc.X + 1]))
                pc.X++;
            else if (key == ConsoleKey.LeftArrow && canMoveHere(mapSpace[pc.Y][pc.X - 1]))
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

            List<int[]> tempList = new List<int[]>();
            List<int> eachLine;
            string[] lineArray;
            string tempString;

            /* How to do this
             * 
             * Get a line from the file
             * Break it into individual numbers
             * parse each number as an int
             * store it as a list
             * 
             * 
             * */
            using (StreamReader sr = new StreamReader("maps/mapLevel0.csv"))
            {
                while ((tempString = sr.ReadLine()) != null)
                {
                    eachLine = new List<int>();

                    lineArray = tempString.Split(',');

                    foreach (string el in lineArray)
                    {
                        eachLine.Add(int.Parse(el));
                    }

                    tempList.Add(eachLine.ToArray());
                }
            }

            mapSpace = tempList.ToArray();
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
            int currentPosition;

            char[,] playingSpace = new char[mapSpace.Length, mapSpace[0].Length];

            for (int row = 0; row < mapSpace.Length; row++)
            {
                for (int col = 0; col < mapSpace[0].Length; col++)
                {
                    // See the map rules for the meaning of each symbol
                    currentPosition = mapSpace[row][col];

                    if (currentPosition == 0)
                        playingSpace[row, col] = '.';
                    else if (currentPosition == 1)
                        playingSpace[row, col] = (char)166;
                    else if (currentPosition == 2)
                        playingSpace[row, col] = ' ';
                    else if (currentPosition == 3)
                        playingSpace[row, col] = '>';
                    else if (currentPosition == 4)
                        playingSpace[row, col] = '<';
                    else if (currentPosition == 100)
                        playingSpace[row, col] = '-';
                    else if (currentPosition >= 100 && currentPosition <= 300)
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

            showMessage();
            #endregion
        }

        private static void showMessage()
        {
            Console.WriteLine();

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
        }
        # endregion
    }
}

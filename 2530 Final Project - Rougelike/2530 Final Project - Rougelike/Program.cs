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
            InitializeGame();

            standableTiles = new List<int> { 0, 3, 4, 100 };

            // Initial Draw
            DrawMap();

            while (!done)
            {
                #region Listen for input, update character updates, execute all other updates
                #region Character
                KeyboardInput(Console.ReadKey(false));
                #endregion Character

                #region Other Stuff
                #endregion Other Stuff
                #endregion
            }


        }

        private static void InitializeGame()
        {
            Console.SetWindowSize(160, 40);

            playingSpaceLeft = 0;
            playingSpaceTop = 0;

            characterList = new List<Character>();
            pc = new PlayerCharacter();
            characterList.Add(pc);
            done = false;

            InitializeMap();
        }

        #region Update Methods
        private static void KeyboardInput(ConsoleKeyInfo keyPressed)
        {
            switch (keyPressed.Key)
            {
                case ConsoleKey.RightArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                    MoveCharacter(keyPressed.Key);
                    break;
                default: break;
            }

            switch (keyPressed.KeyChar)
            {
                case '?':
                    ShowHelpScreen();
                    break;
                case 'o':
                    TryOpenDoor();
                    break;
                case 'Q':
                    done = true;
                    break;
            }
        }

        private static void TryOpenDoor()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Door in which direction?");

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.UpArrow:
                    if (mapSpace[pc.Y - 1][pc.X] >= 101 && mapSpace[pc.Y][pc.X] <= 300)
                        OpenDoor(1);
                    break;
                case ConsoleKey.DownArrow:
                    if (mapSpace[pc.Y + 1][pc.X] >= 101 && mapSpace[pc.Y][pc.X] <= 300)
                        OpenDoor(2);
                    break;
                case ConsoleKey.LeftArrow:
                    if (mapSpace[pc.Y][pc.X - 1] >= 101 && mapSpace[pc.Y][pc.X] <= 300)
                        OpenDoor(3);
                    break;
                case ConsoleKey.RightArrow:
                    if (mapSpace[pc.Y][pc.X + 1] >= 101 && mapSpace[pc.Y][pc.X] <= 300)
                        OpenDoor(4);
                    break;

            }
        }

        private static void OpenDoor(int doorDirection)
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
                // Doesn't work yet.
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

            DrawMap();
        }

        private static void ShowHelpScreen()
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

            DrawMap();
        }

        private static void MoveCharacter(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow && CanMoveHere(mapSpace[pc.Y + 1][pc.X]))
                pc.Y++;
            else if (key == ConsoleKey.UpArrow && CanMoveHere(mapSpace[pc.Y - 1][pc.X]))
                pc.Y--;
            else if (key == ConsoleKey.RightArrow && CanMoveHere(mapSpace[pc.Y][pc.X + 1]))
                pc.X++;
            else if (key == ConsoleKey.LeftArrow && CanMoveHere(mapSpace[pc.Y][pc.X - 1]))
                pc.X--;

            DrawMap();
        }

        private static bool CanMoveHere(int p)
        {
            foreach (int el in standableTiles)
            {
                if (p == el)
                    return true;
            }

            return false;
        }

        private static void InitializeMap()
        {
            message = "This is the message";
            maxMessageCounterValue = 10;
            messageCounter = -1;

            List<int[]> tempList = new List<int[]>();
            List<int> eachLine;
            string[] lineArray;
            string tempString;

            using (StreamReader sr = new StreamReader("maps/mapLevelTest.csv"))
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
        private static char[,] DrawCharacter(char[,] map)
        {
            foreach (Character el in characterList)
            {
                map[el.Y, el.X] = el.CharacterRepresentation;
            }

            return map;
        }

        private static void DrawMap()
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

                    playingSpace[row,col] = DrawTile(currentPosition);
                }
            }

            #endregion

            #region Step 2
            playingSpace = DrawCharacter(playingSpace);
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

            ShowMessage();
            #endregion
        }

        private static char DrawTile(int currentPosition)
        {
            if (currentPosition == 1)
                return (char)9618;
            else if (currentPosition == 2)
                return ' ';
            else if (currentPosition == 3)
                return '>';
            else if (currentPosition == 4)
                return '<';
            else if (currentPosition == 5)
                return (char)9650;
            else if (currentPosition == 6)
                return (char)9617;
            else if (currentPosition == 100)
                return '-';
            else if (currentPosition >= 100 && currentPosition <= 300)
                return '+';
            else
                return '.';
        }

        private static void ShowMessage()
        {
            Console.WriteLine();

            if (message != oldMessage && messageCounter > 0)
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

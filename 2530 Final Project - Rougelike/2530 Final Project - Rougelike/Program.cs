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
        #region Fields
        static PlayerCharacter pc; // Player character object represting the player
        static List<Character> characterList; // A list of all current characters, player, non-player, and monsters
        static bool done; // Keeps the game going until the player inputs 'Q'.
        static int[][] mapSpace; // Contains the current integer array for the map, from the .csv file
        static List<int> standableTiles; // An array of tiles where the character can actually stand
        static string message; // The output message for feedback to the user.
        static string oldMessage; // The previous message
        static int messageCounter; // A counter of how long messages stay on the screen.
        static int maxMessageCounter; // The reset value for the counter above.
        static int maxMessageWidth;
        static int messagePosition; // The area where the message will appear, from the top.
        static StringBuilder messageWiper;
        static MapLevel0 theMap;
        #endregion

        #region Main Method
        static void Main(string[] args)
        {
            maxMessageCounter = 10;
            messagePosition = 43;
            maxMessageWidth = 52;

            theMap = new MapLevel0();

            // Sets up the game for the first time.
            InitializeGame();

            standableTiles = new List<int> { 0, 3, 4, 100 };

            // Initial Draw
            DrawMap();

            while (!done)
            {
                #region Listen for input, update character updates, execute all other updates
                #region Character
                KeyboardInput(Console.ReadKey(false));

                DrawCharacters();
                #endregion Character

                #region Other Stuff
                ShowMessage();
                #endregion Other Stuff
                #endregion
            }


        }

        #endregion


        #region Initialize Methods
        /*  Initialize Game Method
         * 
         * Creates a new game from default values.
         * Will eventually be one of two options, the other being to load from a saved game.
         * */
        private static void InitializeGame()
        {
            messageWiper = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < maxMessageWidth; j++)
                    messageWiper.Append(' ');
                messageWiper.Append('\n');
            }

            Console.SetWindowSize(160, 50); // Size of the console window
            Console.Title = "CSIS Final Project"; // Title of the console window

            pc = new PlayerCharacter();
            pc.X = 5;
            pc.Y = 5;

            characterList = new List<Character>();
            characterList.Add(pc);
            done = false;

            InitializeMap();

            Console.CursorVisible = false;
        }

        private static void InitializeMap()
        {
            mapSpace = theMap.ReadMap();
        }

        //private static List<int[]> ReadMap()
        //{
        //    List<int[]> tempList = new List<int[]>();
        //    List<int> eachLine;
        //    string[] lineArray;
        //    string tempString;

        //    using (StreamReader sr = new StreamReader("maps/mapLevel0.csv"))
        //    {
        //        while ((tempString = sr.ReadLine()) != null)
        //        {
        //            eachLine = new List<int>();

        //            lineArray = tempString.Split(',');

        //            foreach (string el in lineArray)
        //            {
        //                eachLine.Add(int.Parse(el));
        //            }

        //            tempList.Add(eachLine.ToArray());
        //        }
        //    }
        //    return tempList;
        //}
        #endregion

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

        private static void MoveCharacter(ConsoleKey key)
        {
            pc.PreviousPosition = pc.Position;

            if (key == ConsoleKey.DownArrow && CanMoveHere(mapSpace[pc.Y + 1][pc.X]))
                pc.Y++;
            else if (key == ConsoleKey.UpArrow && CanMoveHere(mapSpace[pc.Y - 1][pc.X]))
                pc.Y--;
            else if (key == ConsoleKey.RightArrow && CanMoveHere(mapSpace[pc.Y][pc.X + 1]))
                pc.X++;
            else if (key == ConsoleKey.LeftArrow && CanMoveHere(mapSpace[pc.Y][pc.X - 1]))
                pc.X--;
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

        private static bool CanMoveHere(int p)
        {
            foreach (int el in standableTiles)
            {
                if (p == el)
                    return true;
            }

            return false;
        }
        #endregion

        #region Draw Methods
        private static void DrawCharacters()
        {
            foreach (Character el in characterList)
            {
                Console.SetCursorPosition(el.PreviousX, el.PreviousY);
                Console.Write(SelectTile(mapSpace[el.PreviousY][el.PreviousX]));

                Console.SetCursorPosition(el.X, el.Y);
                Console.Write(el.CharacterRepresentation);

                // Sends the cursor off into no mans land, so it doens't overwrite stuff.
                Console.CursorTop = 41;
            }
        }


        /*  DrawMap Method
         * 
         * * Only runs once per map. *
         * 
         * - Reads the contents of the current mapSpace Array, then adds the result to a stringbuilder for output.
         * - Then writes out the characters and any message that may be wating to be written.
         *  */
        private static void DrawMap()
        {
            // Need to clear the console, so the character draw methods will draw correctly
            // and the character can detect the walls.

            /* Steps
             * 1. Copy mapSpace into into a Stringbuilder using SelectTiles()
             * 2. Print each line of the Stringbuilder
             * 3. Print out each character at it's current location.
             * */
            Console.Clear();

            StringBuilder map = new StringBuilder();

            for (int row = 0; row < mapSpace.Length; row++)
            {
                for (int col = 0; col < mapSpace[row].Length; col++)
                {
                    // Need to figure out which character we want to use for walls.
                    map.Append(SelectTile(mapSpace[row][col]));
                }

                Console.WriteLine(map.ToString());
                map.Clear();
            }

            DrawCharacters();
        }

        private static char SelectTile(int currentPosition)
        {
            MapLevel0 newMap = new MapLevel0();

            foreach (int el in MapLevel0.tileInfo.Keys)
            {
                if (el == currentPosition)
                    return MapLevel0.tileInfo[el].CharacterRepresentation;
            }

            // Should never reach this point, but it shuts the program up...
            return ' ';
        }

        private static void ShowMessage()
        {
            if (message != oldMessage)
            {
                oldMessage = message;

                WipeMessage();
                Console.WriteLine("{0}\n", message);
                messageCounter = maxMessageCounter;
            }
            else if (messageCounter < 0)
                WipeMessage();
            else
                messageCounter--;
        }

        private static void WipeMessage()
        {
            // Wipe out the old message.
            Console.SetCursorPosition(0, messagePosition);
            Console.Write(messageWiper);

            // Reset the position for the next message
            Console.SetCursorPosition(0, messagePosition);
        }
        # endregion
    }
}

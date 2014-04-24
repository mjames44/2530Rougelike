using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Security.Permissions;

namespace _2530_Final_Project___Rougelike
{
    class Program
    {
        #region Delegates
        delegate void SpaceChecker(int mapValue);
        // Delegate that checks the value of the 
        // character is standing on, fires methods.

        #endregion

        #region Fields
        static PlayerCharacter pc; // Player character object represting the player
        static List<Character> characterList; // A list of all current characters, player, non-player, and monsters
        static bool done; // Keeps the game going until the player inputs 'Q'.
        static string message; // The output message for feedback to the user.
        static string oldMessage; // The previous message
        static int messageCounter; // A counter of how long messages stay on the screen.
        static int maxMessageCounter; // The reset value for the counter above.
        static int maxMessageWidth; // Maximum width for messages.
        static int messagePosition; // The area where the message will appear, from the top.
        static StringBuilder messageWiper; // A block of nothing characters to wipeout the message
        static Map currentMap;  // Stores the current map object.
        static SpaceChecker spacecheck;

        public static MethodInfo CheckSpace;
        public static Map newMap;
        public static string pcName;

        #endregion

        #region Main Method
        static void Main(string[] args)
        {
            maxMessageCounter = 10;
            messagePosition = 43;
            maxMessageWidth = 52;

            // Sets up the game for the first time.
            InitializeGame();

            while (!done)
            {
                #region Listen for input, update characters, update maps, execute all other updates
                #region Character
                KeyboardInput(Console.ReadKey(false));

                spacecheck(currentMap.MapSpace[pc.Y][pc.X]);

                DrawCharacters();
                #endregion Character

                #region Map
                if (currentMap != newMap)
                {
                    SaveMap();

                    InitializeMap(newMap);

                    currentMap = newMap;
                }
                #endregion

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
            currentMap = new MapForest1(0);
            newMap = currentMap;
            CheckSpace = typeof(MapForest1).GetMethod("CheckSpace");
            


            InitializeConsole();
            InitializePlayChar();
            InitializeMap(currentMap);

            Console.CursorVisible = false;
        }

        private static void InitializeConsole()
        {
            Console.SetWindowSize(160, 50); // Size of the console window
            Console.Title = "CSIS Final Project"; // Title of the console window

            messageWiper = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < maxMessageWidth; j++)
                    messageWiper.Append(' ');
                messageWiper.Append('\n');
            }
        }

        private static void InitializePlayChar()
        {
            pc = new PlayerCharacter();
            characterList = new List<Character>();
            characterList.Add(pc);

            pcName = pc.Name;
        }

        private static void InitializeMap(Map theMap)
        {
            Delegate methodHolder = Delegate.CreateDelegate(typeof(SpaceChecker), theMap, CheckSpace, false);

            if (methodHolder != null)
            {
                spacecheck = (SpaceChecker)methodHolder;
            }

            pc.Position = theMap.StartingPosition;

            DrawMap(theMap);
            DrawCharacters();
        }
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
                case 'T':
                    foreach (int el in currentMap.TileInfo.Keys)
                    {
                        Console.WriteLine("{0}\t{1}", el, currentMap.TileInfo[el].CharacterRepresentation);
                    }
                    break;
            }
        }

        private static void MoveCharacter(ConsoleKey key)
        {
            pc.PreviousPosition = pc.Position;

            if (key == ConsoleKey.DownArrow && CanMoveHere(currentMap.MapSpace[pc.Y + 1][pc.X]))
                pc.Y++;
            else if (key == ConsoleKey.UpArrow && CanMoveHere(currentMap.MapSpace[pc.Y - 1][pc.X]))
                pc.Y--;
            else if (key == ConsoleKey.RightArrow && CanMoveHere(currentMap.MapSpace[pc.Y][pc.X + 1]))
                pc.X++;
            else if (key == ConsoleKey.LeftArrow && CanMoveHere(currentMap.MapSpace[pc.Y][pc.X - 1]))
                pc.X--;
        }

        private static void TryOpenDoor()
        {
            Console.SetCursorPosition(0, 0);
            message = "Door in which direction?";

            ShowMessage(1);

            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentMap.MapSpace[pc.Y - 1][pc.X] >= 101 && currentMap.MapSpace[pc.Y][pc.X] <= 300)
                        OpenDoor(1);
                    break;
                case ConsoleKey.DownArrow:
                    if (currentMap.MapSpace[pc.Y + 1][pc.X] >= 101 && currentMap.MapSpace[pc.Y][pc.X] <= 300)
                        OpenDoor(2);
                    break;
                case ConsoleKey.LeftArrow:
                    if (currentMap.MapSpace[pc.Y][pc.X - 1] >= 101 && currentMap.MapSpace[pc.Y][pc.X] <= 300)
                        OpenDoor(3);
                    break;
                case ConsoleKey.RightArrow:
                    if (currentMap.MapSpace[pc.Y][pc.X + 1] >= 101 && currentMap.MapSpace[pc.Y][pc.X] <= 300)
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
                    if (pickScore + pc.LockPickSkill >= currentMap.MapSpace[pc.Y - 1][pc.X])
                    {
                        if (currentMap.MapSpace[pc.Y - 1][pc.X] < 300)
                            currentMap.MapSpace[pc.Y - 1][pc.X] = 100;
                        else
                            message = "You can't pick this lock";
                    }

                    break;
                case 2:
                    if (pickScore + pc.LockPickSkill >= currentMap.MapSpace[pc.Y + 1][pc.X])
                    {
                        if (currentMap.MapSpace[pc.Y + 1][pc.X] < 300)
                            currentMap.MapSpace[pc.Y + 1][pc.X] = 100;
                        else
                            message = "You can't pick this lock";
                    }

                    break;
                case 3:
                    if (pickScore + pc.LockPickSkill >= currentMap.MapSpace[pc.Y][pc.X - 1])
                    {
                        if (currentMap.MapSpace[pc.Y][pc.X - 1] < 300)
                            currentMap.MapSpace[pc.Y][pc.X - 1] = 100;
                        else
                            message = "You can't pick this lock";
                    }

                    break;
                // Doesn't work yet.
                case 4:
                    if (pickScore + pc.LockPickSkill >= currentMap.MapSpace[pc.Y][pc.X + 1])
                    {
                        if (currentMap.MapSpace[pc.Y][pc.X + 1] < 300)
                            currentMap.MapSpace[pc.Y][pc.X + 1] = 100;
                        else
                            message = "You can't pick this lock";
                    }

                    break;
            }

            DrawMap(currentMap);
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

            DrawMap(currentMap);
        }

        private static bool CanMoveHere(int p)
        {
            foreach (int el in currentMap.StandableTiles)
            {
                if (p == el)
                    return true;
            }

            return false;
        }

        private static void SaveMap()
        {
            using (StreamWriter sw = new StreamWriter("maps/" + pcName + currentMap.FileName))
            {
                for (int row = 0; row < currentMap.MapSpace.Length; row++)
                {
                    for (int col = 0; col < currentMap.MapSpace[row].Length; col++)
                    {
                        if (col != currentMap.MapSpace[row].Length - 1)
                            sw.Write(currentMap.MapSpace[row][col] + ",");
                        else
                            sw.Write(currentMap.MapSpace[row][col] + "\n");
                    }
                }
            }
        }

        private static Dictionary<int, List<int[]>> AnalyzeArray(Map theMap)
        {
            List<int> whatInts = new List<int>();
            Dictionary<int, List<int[]>> spaces = new Dictionary<int, List<int[]>>();

            for (int row = 0; row < theMap.MapSpace.Length; row++)
            {
                for (int col = 0; col < theMap.MapSpace[row].Length; col++)
                {
                    if (!(whatInts.Contains(theMap.MapSpace[row][col])))
                    {
                        whatInts.Add(theMap.MapSpace[row][col]);
                    }
                }
            }

            foreach (int el in whatInts)
            {
                List<int[]> tempList = new List<int[]>();

                for (int row = 0; row < theMap.MapSpace.Length; row++)
                {
                    for (int col = 0; col < theMap.MapSpace[row].Length; col++)
                    {
                        if (el == theMap.MapSpace[row][col])
                            tempList.Add(new int[] { row, col });
                    }
                }

                spaces.Add(el, tempList);
            }

            return spaces;
        }
        #endregion

        #region Draw Methods
        private static void DrawCharacters()
        {
            foreach (Character el in characterList)
            {
                if (currentMap == newMap)
                {
                    Console.ForegroundColor = currentMap.TileInfo[currentMap.MapSpace[el.PreviousY][el.PreviousX]].Color;
                    Console.SetCursorPosition(el.PreviousX, el.PreviousY);
                    Console.Write(SelectTile(currentMap.MapSpace[el.PreviousY][el.PreviousX],
                        currentMap));
                }

                Console.ForegroundColor = pc.Color;
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
         * - Reads the contents of the current currentMap.MapSpace Array, then adds the result to a stringbuilder for output.
         * - Then writes out the characters and any message that may be wating to be written.
         *  */
        private static void DrawMap(Map theMap)
        {
            // Need to clear the console, so the character draw methods will draw correctly
            // and the character can detect the walls.

            /* Steps
             * 1. Copy currentMap.MapSpace into into a Stringbuilder using SelectTiles()
             * 2. Print each line of the Stringbuilder
             * 3. Print out each character at it's current location.
             * */
            Dictionary<int, List<int[]>> whatIsWhere = AnalyzeArray(theMap);

            Console.Clear();

            foreach (int el in whatIsWhere.Keys)
            {
                Console.ForegroundColor = theMap.TileInfo[el].Color;

                foreach (int[] el2 in whatIsWhere[el])
                {
                    DrawInColor(theMap, el, el2);
                }
            }

            /*StringBuilder map = new StringBuilder();

            for (int row = 0; row < theMap.MapSpace.Length; row++)
            {
                for (int col = 0; col < theMap.MapSpace[row].Length; col++)
                {
                    // Need to figure out which character we want to use for walls.
                    map.Append(SelectTile(theMap.MapSpace[row][col], theMap));
                }

                Console.WriteLine(map.ToString());
                map.Clear();
            }*/
        }

        private static void DrawInColor(Map theMap, int el, int[] el2)
        {
            Console.SetCursorPosition(el2[1], el2[0]);
            Console.Write(theMap.TileInfo[el].CharacterRepresentation);
        }

        private static char SelectTile(int currentPosition, Map theMap)
        {

            foreach (int el in theMap.TileInfo.Keys)
            {
                if (el == currentPosition)
                    return theMap.TileInfo[el].CharacterRepresentation;
            }

            // Should never reach this point, but it shuts the program up...
            return ' ';
        }

        private static void ShowMessage()
        {
            ShowMessage(null);
        }

        private static void ShowMessage(int? i)
        {
            if (message != oldMessage)
            {
                oldMessage = message;

                WipeMessage();
                Console.WriteLine("{0}\n", message);
                messageCounter = i ?? maxMessageCounter;
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
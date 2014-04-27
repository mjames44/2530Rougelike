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
        static string oldMessage; // The previous message
        static int messageCounter; // A counter of how long messages stay on the screen.
        static int maxMessageCounter; // The reset value for the counter above.
        static int maxMessageWidth; // Maximum width for messages.
        static int messagePosition; // The area where the message will appear, from the top.
        static StringBuilder messageWiper; // A block of nothing characters to wipeout the message
        static Map currentMap;  // Stores the current map object.
        static SpaceChecker spacecheck;

        public static string Message { get; set; } // The output message for feedback to the user.
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
                KeyboardInput(Console.ReadKey(true));

                spacecheck(currentMap.MapSpace[pc.Y][pc.X]);

                checkCharacters(); // Who died?
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

        private static void checkCharacters()
        {
            List<int> deadMonsters = new List<int>();

            for (int i = 0; i < characterList.Count; i++)
            {
                if (characterList.ElementAt(i) is Monster)
                {
                    Monster tempMonster = (Monster)characterList.ElementAt(i);
                    if (tempMonster.HP <= 0)
                        deadMonsters.Add(i);
                }
                else if (characterList.ElementAt(i) is PlayerCharacter)
                {
                    if (pc.CurrentHP <= 0)
                    {
                        pc.Death();
                        break;
                    }
                }
            }

            foreach (int el in deadMonsters)
            {
                MonsterDeath(el);
            }

            pc.WriteInfo();
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
            currentMap = new MapMountain(2);
            newMap = currentMap;
            CheckSpace = typeof(MapMountain).GetMethod("CheckSpace");

            InitializeConsole();
            InitializePlayChar();
            InitializeMap(currentMap);

            Console.CursorVisible = false;
        }

        private static void InitializeConsole()
        {
            Console.SetWindowSize(125, 50); // Size of the console window
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
            pc = new PlayerCharacter("Stevo");
            characterList = new List<Character>();
            characterList.Add(pc);

            pcName = pc.Name;
        }

        private static void InitializeMap(Map theMap)
        {
            characterList = new List<Character>();
            characterList.Add(pc);

            Delegate methodHolder = Delegate.CreateDelegate(typeof(SpaceChecker), theMap, CheckSpace, false);

            if (methodHolder != null)
            {
                spacecheck = (SpaceChecker)methodHolder;
            }

            foreach (Character el in theMap.MapCharacters)
            {
                characterList.Add(el);
            }

            pc.Position = theMap.StartingPosition;

            DrawMap(theMap);
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
                case '?': // Help
                    ShowHelpScreen();
                    break;
                case 'o': // open door
                    TryOpenDoor();
                    break;
                case 'Q': // Quit
                    done = true;
                    break;
                case 'T': // List tiles in current map
                    foreach (int el in currentMap.TileInfo.Keys)
                    {
                        Console.WriteLine("{0}\t{1}", el, currentMap.TileInfo[el].CharacterRepresentation);
                    }
                    break;
                case 'i': // show inventory
                    ShowInventory();
                    break;
                case 'r': // Remove Weapon/Armor
                    RemoveItem();
                    break;
            }
        }

        private static void MoveCharacter(ConsoleKey key)
        {
            pc.PreviousPosition = pc.Position;
            List<int[]> occupiedPositions = new List<int[]>();

            if (key == ConsoleKey.DownArrow && CanMoveHere(currentMap.MapSpace[pc.Y + 1][pc.X]))
            {
                if (!SpaceOccupied(pc.Y + 1, pc.X, pc))
                    pc.Y++;
            }
            else if (key == ConsoleKey.UpArrow && CanMoveHere(currentMap.MapSpace[pc.Y - 1][pc.X]))
            {
                if (!SpaceOccupied(pc.Y - 1, pc.X, pc))
                    pc.Y--;
            }
            else if (key == ConsoleKey.RightArrow && CanMoveHere(currentMap.MapSpace[pc.Y][pc.X + 1]))
            {
                if (!SpaceOccupied(pc.Y, pc.X + 1, pc))
                    pc.X++;
            }
            else if (key == ConsoleKey.LeftArrow && CanMoveHere(currentMap.MapSpace[pc.Y][pc.X - 1]))
                if (!SpaceOccupied(pc.Y, pc.X - 1, pc))
                    pc.X--;

            foreach (Character el in characterList)
            {
                occupiedPositions.Add(el.Position);
                occupiedPositions.Add(el.PreviousPosition);
            }

            foreach (Character el in characterList)
            {
                if (el.GetType() != pc.GetType())
                {
                    int[] nextSpace = el.NextSpace(currentMap.MapSpace, currentMap.StandableTiles);

                    if (!SpaceOccupied(nextSpace[0], nextSpace[1], el) && CanMoveHere(currentMap.MapSpace[nextSpace[0]][nextSpace[1]]))
                        el.Move(nextSpace);
                }
            }
        }

        private static bool SpaceOccupied(int y, int x, Character callingCharacter)
        {
            for (int i = 0; i < characterList.Count; i++)
            {
                if (x == characterList[i].X && y == characterList[i].Y)
                {
                    if (callingCharacter is Monster && characterList[i] is PlayerCharacter)
                    {
                        Monster theMonster = (Monster)callingCharacter;

                        pc = theMonster.AttackPlayer(pc);
                    }
                    else if (callingCharacter is PlayerCharacter)
                        pc.Interact(characterList[i]);

                    return true;
                }
            }

            return false;
        }

        internal static void MonsterDeath(int index)
        {
            Monster tempMonster = (Monster)characterList[index];
            AwardXP(tempMonster.XP);
            tempMonster.DropItem();

            Console.ForegroundColor = currentMap.TileInfo[currentMap.MapSpace[tempMonster.PreviousY][tempMonster.PreviousX]].Color;
            Console.SetCursorPosition(tempMonster.PreviousX, tempMonster.PreviousY);
            Console.Write(SelectTile(currentMap.MapSpace[tempMonster.PreviousY][tempMonster.PreviousX],
                currentMap));

            characterList.RemoveAt(index);
        }

        private static void TryOpenDoor()
        {
            Console.SetCursorPosition(0, 0);

            Message = "Door in which direction?";

            ShowMessage(0);

            switch (Console.ReadKey(true).Key)
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
                    if (currentMap.MapSpace[pc.Y - 1][pc.X] != 300)
                    {
                        if (pickScore + pc.LockPickSkill >= currentMap.MapSpace[pc.Y - 1][pc.X])
                        {

                            currentMap.MapSpace[pc.Y - 1][pc.X] = 100;
                        }
                    }
                    else
                    {
                        Message = "You can't pick this lock";
                        ShowMessage(0);
                    }
                    break;
                case 2:
                    if (currentMap.MapSpace[pc.Y + 1][pc.X] != 300)
                    {
                        if (pickScore + pc.LockPickSkill >= currentMap.MapSpace[pc.Y + 1][pc.X])
                        {
                            currentMap.MapSpace[pc.Y + 1][pc.X] = 100;
                        }
                    }
                    else
                    {
                        Message = "You can't pick this lock";
                        ShowMessage(0);

                    }
                    break;
                case 3:
                    if (currentMap.MapSpace[pc.Y][pc.X - 1] != 300)
                    {
                        if (pickScore + pc.LockPickSkill >= currentMap.MapSpace[pc.Y][pc.X - 1])
                        {

                            currentMap.MapSpace[pc.Y][pc.X - 1] = 100;

                        }
                    }
                    else
                    {
                        Message = "You can't pick this lock";
                        ShowMessage(0);
                    }
                    break;
                case 4:
                    if (currentMap.MapSpace[pc.Y][pc.X + 1] != 300)
                    {
                        if (pickScore + pc.LockPickSkill >= currentMap.MapSpace[pc.Y][pc.X + 1])
                        {

                            currentMap.MapSpace[pc.Y][pc.X + 1] = 100;
                        }
                    }
                    else
                    {
                        Message = "You can't pick this lock";
                        ShowMessage(0);
                    }
                    break;
            }

            ShowMessage(0);
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
                    input = Console.ReadKey(true).Key;
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

        public static void AddItem(Item theItem)
        {
            pc.ItemInventory.Add(theItem);

            Message = String.Format("You got {0}", theItem.Name);

            ShowMessage(1);
        }

        internal static void AwardXP(int XP)
        {
            pc.XP += XP;
            pc.CheckXPLevel();
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

                Console.ForegroundColor = el.Color;
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
        internal static void DrawMap()
        { 
            DrawMap(currentMap);
        }

        private static void DrawMap(Map theMap)
        {
            // Need to clear the console, so the character draw methods will draw correctly
            // and the character can detect the walls.

            // New method, with color

            Dictionary<int, List<int[]>> whatIsWhere = AnalyzeArray(theMap);

            Console.Clear();

            foreach (int el in whatIsWhere.Keys)
            {
                try { Console.ForegroundColor = theMap.TileInfo[el].Color; }
                catch { Console.ForegroundColor = ConsoleColor.White; }

                foreach (int[] el2 in whatIsWhere[el])
                {
                    DrawInColor(theMap, el, el2);
                }
            }

            /* Old method, no color
            //* Steps
            // * 1. Copy currentMap.MapSpace into into a Stringbuilder using SelectTiles()
            // * 2. Print each line of the Stringbuilder
            // * 3. Print out each character at it's current location.
            // * 

            StringBuilder map = new StringBuilder();

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

            DrawCharacters();
            pc.WriteInfo();
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



        #region Message Methods
        public static void ShowMessage()
        {
            ShowMessage(null);
        }

        public static void ShowMessage(int? i)
        {
            if (Message != oldMessage)
            {
                oldMessage = Message;

                WipeMessage();
                Console.WriteLine("{0}\n", Message);
                messageCounter = i ?? maxMessageCounter;
            }
            else if (messageCounter < 0)
            {
                WipeMessage();
                oldMessage = "";
                Message = "";
            }
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
        #endregion
        #endregion

        #region Inventory Methods
        private static void ShowInventory()
        {
            if (pc.ItemInventory.Count != 0)
            {
                bool loopDone = false;

                while (!loopDone)
                {
                    Console.SetCursorPosition(0, 0);

                    Console.WriteLine("Which Item? (esc to quit)");

                    for (int i = 0; i < pc.ItemInventory.Count; i++)
                    {
                        Console.WriteLine("{0}) {1}", (char)(i + 97),
                            pc.ItemInventory.ElementAt(i).Name);
                    }

                    ConsoleKeyInfo selection = Console.ReadKey(true);

                    if (selection.Key == ConsoleKey.Escape)
                    {
                        loopDone = true;
                    }

                    if (((int)(selection.KeyChar) - 97) < pc.ItemInventory.Count && (int)(selection.KeyChar) - 97 >= 0)
                    {
                        Item selectedItem = pc.ItemInventory.ElementAt(selection.KeyChar - 97);
                        int itemIndex = (int)selection.KeyChar - 97;

                        bool doneEquip = false;

                        Console.WriteLine();
                        Console.WriteLine("Use as what? (1 - weapon, 2 - armor, 3 - item, esc to quit)");

                        selection = Console.ReadKey(true);

                        while (!doneEquip)
                        {
                            if (selection.Key == ConsoleKey.Escape)
                            {
                                doneEquip = true;
                            }
                            else if (selection.KeyChar == '1')
                            {
                                Message = pc.Equip(selectedItem, "Weapon", itemIndex);

                                doneEquip = true;
                                loopDone = true;
                            }
                            else if (selection.KeyChar == '2')
                            {
                                Message = pc.Equip(selectedItem, "Armor", itemIndex);

                                doneEquip = true;
                                loopDone = true;
                            }
                            else if (selection.KeyChar == '3')
                            {
                                Message = pc.UseItem(selectedItem, itemIndex);

                                doneEquip = true;
                                loopDone = true;
                            }
                        }

                    }

                    Program.DrawMap(currentMap);
                    ShowMessage(0);
                }
            }
            else
            {
                Message = "The Inventory is empty";

                ShowMessage(0);
            }


        }

        private static void RemoveItem()
        {
            bool loopDone = false;





            while (!loopDone)
            {
                Console.SetCursorPosition(0, 0);

                Console.WriteLine("Remove which? (esc to quit)");

                for (int i = 0; i < pc.EquipedItems.Count; i++)
                {
                    Console.WriteLine("{0}) {1}: {2}",
                        (char)(i + 97),
                        pc.EquipedItems.ElementAt(i).Key,
                        pc.EquipedItems.ElementAt(i).Value.Name);
                }

                ConsoleKeyInfo selection = Console.ReadKey(true);

                if (selection.Key == ConsoleKey.Escape)
                {
                    loopDone = true;
                }
                else if ((int)selection.KeyChar - 97 < pc.EquipedItems.Count)
                {
                    int selectedIndex = (int)selection.KeyChar - 97;

                    if (pc.EquipedItems.Values.ElementAt(selectedIndex).GetType() != typeof(NullItem))
                        pc.RemoveItem(pc.EquipedItems.Keys.ElementAt(selectedIndex));

                    loopDone = true;
                }

                DrawMap(currentMap);
            }
        }
        #endregion

    }
}
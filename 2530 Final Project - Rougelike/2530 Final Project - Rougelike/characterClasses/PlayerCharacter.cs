using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class PlayerCharacter : Character
    {
        // Fields
        int[] levelHPProgression;
        int[] levelAttackProgression;
        int[] levelDefenseProgression;
        int[] levelLockpick;
        int[] levelIntervals;
        private int infoLeft;
        private int infoTop;

        // Properties
        public int LockPickSkill { get; private set; }
        public List<Item> ItemInventory { get; set; }
        public Dictionary<string, Item> EquipedItems { get; protected set; }
        public int XP { get; set; }
        public int NextLevel { get; private set; }
        public int Level { get; private set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; protected set; }

        // Constructors
        public PlayerCharacter(string name)
            : base('@', name, ConsoleColor.White, 5, 5, 0, 0, 0)
        {
            levelHPProgression = new int[] { 25, 10, 15, 20, 25, 30 };
            levelAttackProgression = new int[] { 1, 2, 2, 3, 2 };
            levelDefenseProgression = new int[] { 2, 1, 2, 2, 3 };
            levelLockpick = new int[] { 10, 10, 15, 20, 20, 25 };

            levelIntervals = new int[] { 0, 100, 200, 400, 800, 1600, Int16.MaxValue };

            infoLeft = 105;
            infoTop = 2;

            NewPlayerCharacter(name);
            NewCharacterItems();
        }

        // Methods
        private void NewPlayerCharacter(string name)
        {
            Level = 1;
            MaxHP = 25;
            CurrentHP = MaxHP;

            XP = 0;
            NextLevel = 100;

            LockPickSkill = 10;
        }

        private void LevelUp() // Ding!
        {
            Level++;

            MaxHP += levelHPProgression[Level];
            Attack += levelAttackProgression[Level];
            Defense += levelDefenseProgression[Level];
            LockPickSkill += levelLockpick[Level];

            NextLevel = levelIntervals[Level];
        }

        private void NewCharacterItems()
        {
            ItemInventory = new List<Item>(); // Any items to begin with?  Healing potion?

            EquipedItems = new Dictionary<string, Item>();
            EquipedItems.Add("Weapon", new NullItem());
            EquipedItems.Add("Armor", new NullItem());
        }

        public string Equip(Item theItem, string itemType, int index)
        {
            if (EquipedItems[itemType].GetType() != typeof(NullItem))
            {
                RemoveItem(itemType);
            }

            EquipedItems[itemType] = theItem;
            ItemInventory.RemoveAt(index);

            UpdateInventory();

            return String.Format("{0} has been equiped as {1}", theItem.Name, itemType);
        }

        private void UpdateInventory()
        {
            foreach (string el in EquipedItems.Keys)
            {
                if (el == "Weapon")
                {
                    MinDamage = EquipedItems[el].MinDamage;
                    MaxDamage = EquipedItems[el].MaxDamage;
                }
                if (el == "Armor")
                {
                    Armor = EquipedItems[el].DefenseModifier;
                }
            }
        }

        internal string UseItem(Item selectedItem, int index)
        {
            if (selectedItem.HealthModifier > (MaxHP - CurrentHP))
            {
                CurrentHP = MaxHP;
                ItemInventory.RemoveAt(index);

                return String.Format("Your health has changed by {0}", selectedItem.HealthModifier);
            }
            else
            {
                CurrentHP += selectedItem.HealthModifier;
                ItemInventory.RemoveAt(index);

                return String.Format("Your health has increased by {0}", selectedItem.HealthModifier);
            }
        }

        public void WriteInfo()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorTop = infoTop;


            List<string> pcInfo = new List<string>();

            pcInfo.Add(string.Format("Name: {0}\n\n", Name));

            pcInfo.Add(string.Format("Level: {0}\n\n", Level));

            pcInfo.Add(string.Format("Max Health: {0}\n", MaxHP));
            pcInfo.Add(string.Format("Current Health: {0}\n\n", CurrentHP));

            pcInfo.Add(string.Format("Attack: {0}\n", Attack));
            pcInfo.Add(string.Format("Defense: {0}\n", Defense));
            pcInfo.Add(string.Format("Lock Pick Skill: {0}\n\n", LockPickSkill));

            pcInfo.Add(string.Format("totalXP: {0}\n", XP));
            if (NextLevel < 2000)
                pcInfo.Add(string.Format("Next Level: {0}", NextLevel));

            foreach (string el in pcInfo)
            {
                Console.CursorLeft = infoLeft;
                Console.Write(el);
            }
        }

        public void RemoveItem(string itemType)
        {
            ItemInventory.Add(EquipedItems[itemType]);

            EquipedItems[itemType] = new NullItem();

            UpdateInventory();
        }

        public override Character Interact(Character otherChar)
        {
            if (otherChar is Monster)
            {
                Monster monster = (Monster)otherChar; 
                monster = AttackMonster(monster);

                return monster;
            }
            else
            {
                NonPlayerCharacter npc = (NonPlayerCharacter)otherChar;
                npc.Talk();

                return npc;
            }
        }

        private Monster AttackMonster(Monster monster)
        {
            int attackDamage = Attack + GetDamage() - monster.Armor;

            monster.HP -= attackDamage;

            Program.Message = String.Format("You hit the {0} for {1} damage.", monster.Name, attackDamage);

            return monster;
        }

        internal void CheckXPLevel()
        {
            if (XP > NextLevel)
            {
                LevelUp();
            }
        }

        public void Death()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    abstract class Monster : Character, NonPlayer
    {
        public int XP { get; protected set; }

        public Monster(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int HP { get; set; }

        public abstract void DropItem();

        internal PlayerCharacter AttackPlayer(PlayerCharacter player)
        {
            int attackDamage = Attack + GetDamage() - (player.Defense + player.Armor);

            player.CurrentHP -= attackDamage;

            Program.Message = String.Format("{0} hit you for {1} damage.", player.Name, attackDamage);

            return player;
        }
    }
}

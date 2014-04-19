using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class PlayerCharacter : Character
    {
        public int LockPickSkill {get; private set;}
        public string Name { get; private set; }
       
        public PlayerCharacter()
        {
            CharacterRepresentation = '@';
            LockPickSkill = 100;
            HP = 25;
            Name = "Stevo";
        }
    }
}

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

        public PlayerCharacter()
        {
            X = 5;
            Y = 5;
            CharacterRepresentation = '@';
            LockPickSkill = 100;
        }
    }
}

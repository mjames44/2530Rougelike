using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    abstract class NonPlayerCharacter : Character
    {
        public string[] SpeechArray { get; protected set; }
        protected int count;

        public NonPlayerCharacter(int x, int y)
        {
            X = x;
            Y = y;

            count = 0;
        }

        public void Talk()
        {
            count++;

            Program.Message = String.Format("{0}: {1}", Name, SpeechArray[count % SpeechArray.Length]);
            Program.ShowMessage(0);
        }

        // Doesn't interact with others, can be interacted with.
        public override Character Interact(Character otherChar) { return this; }
    }
}

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
        protected int talkCount;
        protected int moveCount;

        public NonPlayerCharacter(int x, int y)
        {
            X = x;
            Y = y;

            talkCount = 0;
        }

        public void Talk()
        {
            talkCount++;

            Game.Message = String.Format("{0}: {1}", Name, SpeechArray[talkCount % SpeechArray.Length]);
            Game.ShowMessage(0);
        }
        
        public override void Move(int[] space)
        {
            if (moveCount++ % 3 == 0)
            {
                base.Move(space);
            }
        }
    }
}

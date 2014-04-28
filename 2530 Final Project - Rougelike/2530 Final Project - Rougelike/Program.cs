using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final_Project___Rougelike
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Please name your hero.");
            string name = Console.ReadLine().Split(' ')[0];

            Game theGame = new Game(new MapForest1(0), name);
        }
    }
}

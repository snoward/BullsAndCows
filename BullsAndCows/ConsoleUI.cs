using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    internal class ConsoleUI
    {
        static void Main(string[] args)
        {
            var game = new Game(new EasyAI());
            while (!game.IsOver)
            {
                game = game.NextStep();
            }
            Console.WriteLine(game.Winner.Name + " Wins");
        }
    }
}

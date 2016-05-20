using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class ConsoleUI
    {
        public Game CurrentGame { get; private set;}
        public ConsoleUI(Game game)
        {
            CurrentGame = game;
        }

        public void Run()
        {
            while (!CurrentGame.IsOver)
            {
                UpdateView();
                CurrentGame = CurrentGame.NextStep();
                Console.Beep();
            }
            Console.WriteLine(CurrentGame.Winner.Name + " Wins");
        }

        public void UpdateView()
        {
            CurrentGame.PrintGame();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class ConsoleUi : IGameUi
    {
        public Game CurrentGame { get; private set;}

        public ConsoleUi()
        {
        }

        public string GetPlayerName()
        {
            Console.WriteLine("Введите имя игрока");
            var name = Console.ReadLine();
            return name;
        }

        public string GetPlayerNumber()
        {
            Console.WriteLine("Введите ваше секретное число");
            return Console.ReadLine();
        }

        public string GetNumber()
        {
            Console.WriteLine("Введите число");
            return Console.ReadLine();
        }

        public void PrintBullsCows(string bullsCows)
        {
            Console.WriteLine(bullsCows);
        }

        public void PrintWinner(string winner)
        {
            Console.WriteLine(winner + " победил!");
        }

        public void UpdateView(Game currentGame)
        {
            Console.Clear();
            foreach (var name in currentGame.Moves.Keys)
                Console.Write(name + "\t\t\t\t");

            //for (var i = 0; i < CurrentGame.CurrentPlayer.)
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class ConsoleUi : IGameUi
    {
        public string SnowGetPlayerNameDialog()
        {
            Console.WriteLine("Введите имя игрока");
            var name = Console.ReadLine();
            return name;
        }

        public string SnowGetPlayerNumberDialog()
        {
            Console.WriteLine("Введите ваше секретное число");
            return Console.ReadLine();
        }

        public string SnowGetNumberDialog()
        {
            Console.WriteLine("Введите число");
            return Console.ReadLine();
        }

        public void SnowWinnerName(string winner)
        {
            Console.WriteLine(winner + " победил!");
        }

        public void UpdateView(Game game)
        {
            Console.Clear();
            Console.WriteLine($"{game.CurrentPlayer.Name}				{game.NextPlayer.Name}");
            for (var i = 0; i < game.Moves[game.CurrentPlayer].Count; i++)
            {
                var currentPlayer = game.Moves[game.CurrentPlayer][i];
                var nextPlayer = game.Moves[game.NextPlayer][i];
                var currentBullsCows = GameNumber.GetBullAndCows(game.NextPlayer.PlayerNumber, currentPlayer);
                var nextBullsCows = GameNumber.GetBullAndCows(game.CurrentPlayer.PlayerNumber, nextPlayer);
                Console.WriteLine($@"{currentPlayer} {currentBullsCows}			{nextPlayer} {nextBullsCows}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class Game
    {
        public const int NumberLength = 4;
        public IPlayer CurrentPlayer { get; private set; }
        public IPlayer NextPlayer { get; private set; }
        public bool IsOver => CurrentPlayer.IsWinner || NextPlayer.IsWinner;

        public Game()
        {
            CurrentPlayer = new Player();
            NextPlayer = new Player();
        }

        public Game(IPlayer opponent)
        {
            CurrentPlayer = new Player();
            NextPlayer = opponent;
        }

        public Game NextStep()
        {
            Console.WriteLine(CurrentPlayer.Name + "s' turn");
            var number = new GameNumber(Console.ReadLine());
            CurrentPlayer.TellNumber(number, NextPlayer);
            SwapPlayerRoles();
            return this;
        }

        public void SwapPlayerRoles()
        {
            var tmp = CurrentPlayer;
            CurrentPlayer = NextPlayer;
            NextPlayer = tmp;
        }

        public static Tuple<int, int> GetBullAndCows(GameNumber real, GameNumber suggest)
        {
            var bulls = 0;
            var cows = 0;
            foreach (var digit in suggest.Number)
            {
                if (!real.Number.Contains(digit))
                    continue;
                var realPosition = real.Number.IndexOf(digit);
                var suggestPosition = suggest.Number.IndexOf(digit);
                if (realPosition == suggestPosition)
                    bulls++;
                else
                    cows++;
            }
            return Tuple.Create(bulls, cows);
        }
    }
}

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
        public IPlayer Winner => CurrentPlayer.IsWinner ? CurrentPlayer : NextPlayer;

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
            //Console.WriteLine(CurrentPlayer.Name + "s' turn");
            CurrentPlayer.TellNumber(NextPlayer);
            SwapPlayerRoles();
            return this;
        }

        public void SwapPlayerRoles()
        {
            var tmp = CurrentPlayer;
            CurrentPlayer = NextPlayer;
            NextPlayer = tmp;
        }

        public void PrintGame()
        {
            Console.Clear();
            Console.WriteLine($"{CurrentPlayer.Name}\t\t\t\t{NextPlayer.Name}");
            for (var i = 0; i < CurrentPlayer.Moves.Count; i++)
            {
                var currentPlayerNumber = CurrentPlayer.Moves[i];
                var nextPlayerNumber = NextPlayer.Moves[i];
                var currentPlayerAnswer = GameNumber.GetBullAndCows(NextPlayer.PlayerNumber, currentPlayerNumber);
                var nextPlayerAnswer = GameNumber.GetBullAndCows(CurrentPlayer.PlayerNumber, nextPlayerNumber);
                Console.WriteLine($"{currentPlayerNumber} {currentPlayerAnswer}\t\t\t{nextPlayerNumber} {nextPlayerAnswer}");
            }
        }
    }
}

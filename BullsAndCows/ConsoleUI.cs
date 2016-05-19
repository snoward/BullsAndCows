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
        private readonly List<string> _playerNames;
        private readonly List<IPlayer> players;
        public ConsoleUI(Game game)
        {
            CurrentGame = game;
            players = new List<IPlayer> {CurrentGame.CurrentPlayer, CurrentGame.NextPlayer};
            _playerNames = new List<string> {CurrentGame.CurrentPlayer.Name, CurrentGame.NextPlayer.Name};
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
            //Console.Clear();
            //Console.WriteLine($"{_playerNames[0]}\t\t\t\t{_playerNames[1]}");
            //for (int i = 0; i < CurrentGame.CurrentPlayer.Moves.Count; i++)
            //{
            //    var currentPlayerNumber = players[0].Moves[i];
            //    var nextPlayerNumber = players[1].Moves[i];
            //    Console.WriteLine($"{currentPlayerNumber}\t\t\t\t{nextPlayerNumber}");
            //}
        }
    }
}

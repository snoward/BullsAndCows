using System;
using System.Collections.Generic;
using System.IO;
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
        public bool IsOver => CurrentPlayer.IsLoser || NextPlayer.IsLoser;
        public IPlayer Winner => CurrentPlayer.IsLoser ? NextPlayer : CurrentPlayer;
        public Dictionary<IPlayer, List<GameNumber>> Moves { get; private set; }


        public Game(IPlayer one, IPlayer another)
        {
            CurrentPlayer = one;
            NextPlayer = another;
            Moves = new Dictionary<IPlayer, List<GameNumber>>
            {
                [CurrentPlayer] = new List<GameNumber>(),
                [NextPlayer] = new List<GameNumber>()
            };
        }

        public Game NextStep(GameNumber nextNumber)
        {
            NextPlayer.AcceptMove(nextNumber);
            Moves[CurrentPlayer].Add(nextNumber);
            SwapPlayerRoles();
            return this;
        }

        public void SwapPlayerRoles()
        {
            var tmp = CurrentPlayer;
            CurrentPlayer = NextPlayer;
            NextPlayer = tmp;
        }

        public string CheckNumber(GameNumber currentNumber)
        {
            NextPlayer.AcceptMove(currentNumber);
            var bullsAndCows = GameNumber.GetBullAndCows(currentNumber, NextPlayer.PlayerNumber);
            return bullsAndCows;
        }
    }
}

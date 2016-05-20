using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BullsAndCows
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }
        public bool IsWinner { get; private set; }
        public GameNumber PlayerNumber { get; }

        public List<GameNumber> Moves { get; private set; }

        public Player()
        {
            Console.WriteLine("Enter the player name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your game number");
            PlayerNumber = new GameNumber(Console.ReadLine());
            Moves = new List<GameNumber>();
        }

        public void TellNumber(IPlayer opponent)
        {
            var number = new GameNumber(Console.ReadLine());
            Moves.Add(number);
            var isNumberFound = opponent.AcceptMove(number);
            IsWinner = isNumberFound;
        }

        public bool AcceptMove(GameNumber opponentSuggestNumber)
        {
            //Console.WriteLine(Game.GetBullAndCows(PlayerNumber, opponentSuggestNumber));
            return opponentSuggestNumber.Equals(PlayerNumber);
        }
    }
}
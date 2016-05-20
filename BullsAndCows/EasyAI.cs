using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class EasyAI : IPlayer  
    {
        public string Name { get; }
        public GameNumber PlayerNumber { get; }
        public bool IsWinner { get; private set; }
        public List<GameNumber> Moves { get; private set; }

        public EasyAI()
        {
            Name = "EasyAI";
            PlayerNumber = GameNumber.GenerateRandomNumber();
            Console.WriteLine("TSss.... My number is " + PlayerNumber);
            Moves = new List<GameNumber>();
        }

        public void TellNumber(IPlayer opponent)
        {
            var number = GameNumber.GenerateRandomNumber();
            Moves.Add(number);
            //Console.WriteLine("I think it is " + number.Number);
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

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
        public GameNumber OpponentNumber { get; private set; }
        public bool IsWinner => OpponentNumber != null;

        public EasyAI()
        {
            Name = "EasyAI";
            PlayerNumber = GameNumber.GenerateRandomNumber();
            Console.WriteLine("TSss.... My number is " + PlayerNumber);
        }

        public void TellNumber(IPlayer opponent)
        {
            var number = GameNumber.GenerateRandomNumber();
            Console.WriteLine("I think it is " + number.Number);
            opponent.AcceptMove(number);
        }

        public void AcceptMove(GameNumber opponentSuggestNumber)
        {
            Console.WriteLine(Game.GetBullAndCows(PlayerNumber, opponentSuggestNumber));
            if (!opponentSuggestNumber.Equals(PlayerNumber))
                return;
            OpponentNumber = opponentSuggestNumber;
        }
    }
}

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
        public GameNumber OpponentNumber { get; }
        public bool IsWinner => OpponentNumber != null;


        public EasyAI()
        {
            Name = "EasyAI";
            PlayerNumber = GameNumber.GenerateRandomNumber();
        }

        public void TellNumber(GameNumber number, IPlayer opponent)
        {
            opponent.AcceptMove(number);
        }

        public void AcceptMove(GameNumber opponentSuggestNumber)
        {
            Console.WriteLine(Game.GetBullAndCows(PlayerNumber, opponentSuggestNumber));
            if (opponentSuggestNumber.Equals(PlayerNumber))
                Console.WriteLine("Win");
        }
    }
}

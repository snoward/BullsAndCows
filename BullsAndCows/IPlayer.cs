using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public interface IPlayer
    {
        bool IsWinner { get; }
        string Name { get; }
        GameNumber PlayerNumber { get; }
        GameNumber OpponentNumber { get; }

        void TellNumber(GameNumber number, IPlayer nextPlayer);
        void AcceptMove(GameNumber number);
    }
}

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
        List<GameNumber> Moves { get; }
        GameNumber PlayerNumber { get; }
        void TellNumber(IPlayer nextPlayer);
        bool AcceptMove(GameNumber number);
    }
}

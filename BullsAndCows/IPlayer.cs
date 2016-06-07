using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public interface IPlayer
    {
        string Name { get; }
        GameNumber PlayerNumber { get; }
        bool IsWinner { get; }
        void AcceptMove(GameNumber number);
    }
}

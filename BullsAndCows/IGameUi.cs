using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public interface IGameUi
    {
        string GetPlayerName();
        string GetPlayerNumber();
        string GetNumber();
        void PrintBullsCows(string bullsCows);
        void PrintWinner(string winner);
        void UpdateView(Game game);
    }
}

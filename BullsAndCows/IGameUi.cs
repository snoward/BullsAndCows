using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public interface IGameUi
    {
        string SnowGetPlayerNameDialog();
        string SnowGetPlayerNumber();
        string SnowGetNumber();
        void SnowWinnerName(string winner);
        void UpdateView(Game game);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class NewNetworkController
    {
        public IGameUi player { get; private set; }
        public IGameUi opponent { get; private set; }

        public NewNetworkController(IGameUi player, IGameUi opponent)
        {
            this.player = player;
            this.opponent = opponent;
        }

        public IPlayer CreatePlayer()
        {
            
        }
    }
}

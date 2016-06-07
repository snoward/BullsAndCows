using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BullsAndCows
{
    public class Player : IPlayer
    {
        public string Name { get; }
        public GameNumber PlayerNumber { get; }
        public bool IsWinner { get; private set; }

        public Player(string name, GameNumber number)
        {
            Name = name;
            PlayerNumber = number;
        }

        public void AcceptMove(GameNumber number)
        {
            IsWinner = number.Equals(PlayerNumber);
        }
    }
}
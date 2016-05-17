﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BullsAndCows
{
    public class Player : IPlayer
    {
        public string Name { get; private set; }
        public List<GameNumber> OpponentsMoves { get; private set; }
        public bool IsWinner => OpponentNumber != null;
        public GameNumber PlayerNumber { get; }
        public GameNumber OpponentNumber { get; private set; }
              
        public Player()
        {
            Console.WriteLine("Enter the player name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your game number");
            PlayerNumber = new GameNumber(Console.ReadLine());
            OpponentsMoves = new List<GameNumber>();
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
            OpponentsMoves.Add(opponentSuggestNumber);
        }
    }
}
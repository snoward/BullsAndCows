﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class GameNumber
    {
        public string Number { get; }

        public GameNumber(string number)
        {
            if (number.Length != Game.NumberLength)
                throw new ArgumentException("Number length must be " + Game.NumberLength);
            if (!number.All(char.IsDigit))
                throw new ArgumentException("Incorrect number format. Use only digits.");
            if (number.ToCharArray().Distinct().Count() != Game.NumberLength)
                throw new ArgumentException("Every digit must be unique");
            Number = number;
        }

        public static GameNumber GenerateRandomNumber()
        {
            var candidates = new HashSet<int>();
            var random = new Random();
            while (candidates.Count < Game.NumberLength)
            {
                candidates.Add(random.Next(0, 9));
            }

            var result = new List<int>();
            result.AddRange(candidates);

            return new GameNumber(string.Join("", result.ToArray()));
        }

        public override string ToString()
        {
            return Number;
        }

        public bool Equals(GameNumber number)
        {
            return Number == number.Number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((GameNumber)obj);
        }   

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public static string GetBullAndCows(GameNumber real, GameNumber suggest)
        {
            var bulls = 0;
            var cows = 0;
            foreach (var digit in suggest.Number)
            {
                if (!real.Number.Contains(digit))
                    continue;
                var realPosition = real.Number.IndexOf(digit);
                var suggestPosition = suggest.Number.IndexOf(digit);
                if (realPosition == suggestPosition)
                    bulls++;
                else
                    cows++;
            }
            
            return string.Format($"({bulls}б {cows}к)");
        }
    }
}

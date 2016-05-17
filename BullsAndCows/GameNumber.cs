using System;
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
            if (number.Where(char.IsDigit).ToArray().Length != Game.NumberLength)
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

        public override bool Equals(object obj)
        {
            if (!(obj is GameNumber))
                return false;
            var number = (GameNumber) obj;
            return string.Equals(number.Number, Number);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}

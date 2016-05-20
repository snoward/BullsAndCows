using System;
using NUnit.Framework;
using FluentAssertions;
using FakeItEasy;

namespace BullsAndCows.Tests
{
    [TestFixture]
    public class GameNumber_should
    {
        [Test]
        public void ThrowsExceptionOnNumberWithLetters()
        {
            Action numberCreation = () => new GameNumber("Mo42");
            numberCreation.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void ThrowExceptionOnNumberWithUniqueDigits()
        {
            Action numberCreation = () => new GameNumber("9666");
            numberCreation.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void ThrowExceptionOnNumberOfIncorrectLength()
        {
            Action numberCreation = () => new GameNumber("12345");
            numberCreation.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void GenerateCorrectRandomValue()
        {
            var generateRandomNumber = GameNumber.GenerateRandomNumber();
            Assert.That(generateRandomNumber, Is.InstanceOf(typeof (GameNumber)));
        }

        [Test]
        public void BeEqualToTheSameGameNumber()
        {
            var one = new GameNumber("1234");
            var another = new GameNumber("1234");
            one.Should().Be(another);
        }

        [Test]
        public void CountNoBullsAndNoCows()
        {
            var playerNumber = new GameNumber("1234");
            var guess = new GameNumber("9876");

            var actualResult = GameNumber.GetBullAndCows(playerNumber, guess);
            const string expectedResult = "(0б 0к)";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CountCowsWell()
        {
            var playerNumber = new GameNumber("1234");
            var guess = new GameNumber("4321");

            var actualResult = GameNumber.GetBullAndCows(playerNumber, guess);
            const string expectedResult = "(0б 4к)";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CountBullsWell()
        {
            var playerNumber = new GameNumber("1234");
            var guess = new GameNumber("1234");

            var actualResult = GameNumber.GetBullAndCows(playerNumber, guess);
            const string expectedResult = "(4б 0к)";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}

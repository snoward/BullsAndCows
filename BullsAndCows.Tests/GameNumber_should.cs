using System;
using NUnit.Framework;
using FluentAssertions;

namespace BullsAndCows.Tests
{
    [TestFixture]
    public class GameNumber_should
    {
        [Test]
        public void NotConainsLetter()
        {
            Action numberCreation = () => new GameNumber("Mo42");
            numberCreation.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void ContainsUniqueDigits()
        {
            Action numberCreation = () => new GameNumber("9666");
            numberCreation.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void BeCorrectLength()
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
    }
}

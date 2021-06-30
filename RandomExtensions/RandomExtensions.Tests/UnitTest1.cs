using System;
using NUnit.Framework;

namespace RandomExtensions.Tests
{
    public class Tests
    {
        readonly Random _random = new Random();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var dieRoll = _random.RollDie(6);
            Assert.GreaterOrEqual(dieRoll, 1);
            Assert.LessOrEqual(dieRoll, 6);
        }
    }
}

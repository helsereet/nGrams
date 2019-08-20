using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedOutOfRange_ThrowArgumentOutOfRangeException(int number)
        {
            var pointsCalculator = new DemeritPointsCalculator();

            Assert.That(() => pointsCalculator.CalculateDemeritPoints(number), 
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(60, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
           var pointsCalculator = new DemeritPointsCalculator();

           var result = pointsCalculator.CalculateDemeritPoints(speed);
           
           Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
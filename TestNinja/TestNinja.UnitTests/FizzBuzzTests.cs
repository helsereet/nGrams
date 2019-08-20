using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(3)]
        [TestCase(9)]
        [TestCase(18)]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz(int number)
        {
            var result = FizzBuzz.GetOutput(number);
            
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(50)]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz(int number)
        {
            var result = FizzBuzz.GetOutput(number);
            
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz(int number)
        {
            var result = FizzBuzz.GetOutput(number);
            
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(21)]
        [TestCase(34)]
        public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnTheSameNumber(int number)
        {
            var result = FizzBuzz.GetOutput(number);
            
            Assert.That(result, Is.EqualTo(result));
        }
    }
}
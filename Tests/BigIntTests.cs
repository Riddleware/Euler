using Euler.Lib;
using NUnit.Framework;

namespace Euler.Tests
{
    [TestFixture]
    public class BigIntTests
    {
        [Test]
        [TestCase(0,0, ExpectedResult = "0")]
        [TestCase(1, 0, ExpectedResult = "1")]
        [TestCase(1, 1, ExpectedResult = "2")]
        [TestCase(1123, 1, ExpectedResult = "1124")]
        [TestCase(666, 666, ExpectedResult = "1332")]
        public string Addition(int a, int b)
        {
            var bA = new BigInt(a);
            var bB = new BigInt(b);

            return (bA + bB).ToString();
        }
    }
}
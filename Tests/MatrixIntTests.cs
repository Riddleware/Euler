using Euler.Lib;
using NUnit.Framework;

namespace Euler.Tests
{
    [TestFixture]
    public class MatrixIntTests
    {
        [Test]
        public void SplitTotAndCarryTest()
        {
            var tnc = new MatrixInt().SplitTotAndCarry(12345);
            Assert.That(tnc.Item1, Is.EqualTo(1234));
            Assert.That(tnc.Item2, Is.EqualTo(5));
        }
    }
}

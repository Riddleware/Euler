using Euler.Solutions;
using NUnit.Framework;

namespace Euler.Tests
{
    [TestFixture]
    public partial class SolutionTests
    {
        [Test]
        public void Test_00808()
        {
            BaseTest<int, long>(new _808(), 0, 3807504276997394);
        }
        
        [Test]
        public void Test_00112()
        {
            BaseTest<long, long>(new _112(), 0, 1587000);
        }
        
        [Test]
        public void Test_0092()
        {
            BaseTest<int, long>(new _92(), 10000000, 8581146);
        }
        
        [Test]
        public void Test_0079()
        {
            BaseTest(new _79(), "73162890");
        }

        [Test]
        public void Test_0059()
        {
            BaseTest(new _59(), 129448);
        }
        
        [Test]
        public void Test_0058()
        {
            BaseTest<int, long>(new _58(), 0, 26241);
        }

        [Test]
        public void Test_0054()
        {
            Assert.That(_54.Run(), Is.EqualTo(376));
        }
        
        [Test]
        public void Test_0052()
        {
            BaseTest<int, long>(new _52(), 0, 142857);
        }
        
        [Test]
        public void Test_0051()
        {
            BaseTest<int, long>(new _51(), 0, 121313);
        }
        
        [Test]
        public void Test_0050()
        {
            BaseTest<int, long>(new _50(), 0, 997651);
        }

        [Test]
        public void Test_0049()
        {
            BaseTest<int, string>(new _49(), 0, "296962999629");
        }
        
        [Test]
        public void Test_0048()
        {
            BaseTest<int, string>(new _48(), 0, "9110846700");
        }
        
        [Test]
        public void Test_0047()
        {
            BaseTest<int, long>(new _47(), 0, 134043);
        }
        
        [Test]
        public void Test_0046()
        {
            Assert.That(_46.Run(), Is.EqualTo(5777));
        }

        [Test]
        public void Test_0045()
        {
            BaseTest<int, long>(new _45(), 0, 1533776805);
        }
        
        [Test]
        public void Test_0044()
        {
            BaseTest<int, long>(new _44(), 0, 5482660);
        }
        
        [Test]
        public void Test_0043()
        {
            BaseTest<int, long>(new _43(), 0, 16695334890);
        }
        
        [Test]
        public void Test_0042()
        {
            Assert.That(_42.Run(), Is.EqualTo(162));
        }

        [Test]
        public void Test_0041()
        {
            Assert.That(_41.Run(), Is.EqualTo(7652413));
        }
    }
}
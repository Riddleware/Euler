using Euler.Lib;
using NUnit.Framework;
using System.Collections.Generic;

namespace Euler.Tests
{
    [TestFixture]
    public class Extensions
    {
        [Test]
        public void CollatzChainCountTest()
        {
            long t = 13;
            Assert.That(t.CollatzChainCount(), Is.EqualTo(10));
        }

        [Test]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(11, ExpectedResult = true)]
        [TestCase(111, ExpectedResult = true)]
        [TestCase(1111, ExpectedResult = true)]
        [TestCase(11011, ExpectedResult = true)]
        [TestCase(12, ExpectedResult = false)]
        [TestCase(1212, ExpectedResult = false)]
        [TestCase(11001, ExpectedResult = false)]
        public bool Palindrome(long n)
        {
            return n.IsPalindrome();
        }

        [Test]
        public void GetPrimeFactorisationTest()
        {
            long l = 144;
            var t = l.GetPrimeFactorisation();

        }

        [Test]
        public void GetDivisorCountTest()
        {
            long l = 144;
            Assert.That(l.GetDivisorCount(), Is.EqualTo(15));
        }

        private List<int> expected = new List<int>
        {
            0,
            "One".Length,
            "Ten".Length,
            "OneHundred".Length,
            "OneHundredAndOne".Length,
            "OneHundredAndEleven".Length,
            "OneHundredAndTwentyOne".Length,
            "ninehundredandninetynine".Length,
            "OneThousand".Length,
            "Se7en".Length,

            "two".Length,
            "three".Length,
            "four".Length,
            "five".Length,
            "six".Length,
            "seven".Length,
            "eight".Length,
            "nine".Length,
            "t3n".Length,
            "eleven".Length,
            "twelve".Length,
            "thirteen".Length,
            "fourteen".Length,
            "fifteen".Length,
            "sixteen".Length,
            "seventeen".Length,
            "eighteen".Length,
            "nineteen".Length,
            "twenty".Length,
            "thirty".Length,
            "forty".Length,
            "fifty".Length,
            "sixty".Length,
            "seventy".Length,
            "eighty".Length,
            "ninety".Length,

            "onehundred".Length,
            "twohundred".Length,
            "threehundred".Length,
            "fourhundred".Length,
            "fivehundred".Length,
            "sixhundred".Length,
            "sevenhundred".Length,
            "eighthundred".Length,
            "ninehundred".Length,

        };

        [Test]
        [TestCase(1,1)]
        [TestCase(10, 2)]
        [TestCase(100, 3)]
        [TestCase(101, 4)]
        [TestCase(111, 5)]
        [TestCase(121, 6)]
        [TestCase(999, 7)]
        [TestCase(1000, 8)]
        [TestCase(7, 9)]
        [TestCase(2, 10)]
        [TestCase(3, 11)]
        [TestCase(4, 12)]
        [TestCase(5, 13)]
        [TestCase(6, 14)]
        [TestCase(7, 15)]
        [TestCase(8, 16)]
        [TestCase(9, 17)]
        [TestCase(10, 18)]
        [TestCase(11, 19)]
        [TestCase(12, 20)]
        [TestCase(13, 21)]
        [TestCase(14, 22)]
        [TestCase(15, 23)]
        [TestCase(16, 24)]
        [TestCase(17, 25)]
        [TestCase(18, 26)]
        [TestCase(19, 27)]
        [TestCase(20, 28)]
        [TestCase(30, 29)]
        [TestCase(40, 30)]
        [TestCase(50, 31)]
        [TestCase(60, 32)]
        [TestCase(70, 33)]
        [TestCase(80, 34)]
        [TestCase(90, 35)]

        [TestCase(100, 36)]
        [TestCase(200, 37)]
        [TestCase(300, 38)]
        [TestCase(400, 39)]
        [TestCase(500, 40)]
        [TestCase(600, 41)]
        [TestCase(700, 42)]
        [TestCase(800, 43)]
        [TestCase(900, 44)]

        public void NumWordCountTest(int n, int e)
        {
            Assert.That(NumWordCount.Count(n),Is.EqualTo(expected[e]));
        }



    }
}

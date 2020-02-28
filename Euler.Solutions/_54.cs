using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _54
    {
        enum Suit { Clubs, Spades, Diamonds, Hearts };

        class Card : IComparable<Card>
        {
            public int Value { get; set; }
            public Suit suit { get; set; }

            public Card(string Symbol)
            {
                char v = Symbol[0];
                char s = Symbol[1];

                switch (s)
                {
                    case 'C':
                        suit = Suit.Clubs;
                        break;
                    case 'S':
                        suit = Suit.Spades;
                        break;
                    case 'D':
                        suit = Suit.Diamonds;
                        break;
                    case 'H':
                        suit = Suit.Hearts;
                        break;
                }

                switch (v)
                {
                    case 'T':
                        Value = 10;
                        break;
                    case 'J':
                        Value = 11;
                        break;
                    case 'Q':
                        Value = 12;
                        break;
                    case 'K':
                        Value = 13;
                        break;
                    case 'A':
                        Value = 14;
                        break;
                    default:
                        Value = v - 48;
                        break;
                }
            }
            
            public int Compare(Card x, Card y)
            {
                return x.Value > y.Value ? 1 : x.Value == y.Value ? 0 : -1;
            }

            public int CompareTo(Card y)
            {
                return this.Value > y.Value ? 1 : this.Value == y.Value ? 0 : -1;
            }
        }

        class Hand : List<Card>, IComparable<Hand>
        {
            public Hand(string s)
            {
                var cds = s.Split(' ');
                foreach (var c in cds)
                    Add(new Card(c));
                
                Sort();
                
                GetScore();
            }

            public List<int> Score { get; set; } = new List<int>();

            void GetScore()
            {
                if (IsRoyalFlush())
                {}
                else if (IsStraightFlush())
                { }
                else if (IsPoker())
                { }
                else if (IsFullHouse())
                { }
                else if (IsFlush())
                { }
                else if (IsStraight())
                { }
                else if (IsThree())
                { }
                else if (IsTwoPair())
                { }
                else if (IsPair())
                { }
                else Highest();
            }

            bool IsRoyalFlush(bool addScore = true)
            {
                if (IsFlush(false) && IsStraight(false) && this[Count-1].Value == 14)
                {
                    if (addScore)
                        Score.Add(10);
                    return true;
                }

                return false;
            }

            bool IsStraightFlush(bool addScore = true)
            {
                if (IsFlush(false) && IsStraight(false))
                {
                    if (addScore)
                    {
                        Score.Add(9);
                        Score.Add(this[this.Count - 1].Value);
                    }

                    return true;
                }

                return false;
            }

            bool IsPoker(bool addScore = true)
            {
                var grps = this.GroupBy(c => c.Value).ToList();
                var p = grps.FirstOrDefault(g => g.Count() == 4);
                if (p != null)
                {
                    if (addScore)
                    {
                        Score.Add(8);
                        Score.Add(p.Key);
                        Score.Add(grps.First(g => g.Count() == 1).Key);
                    }

                    return true;
                }

                return false;
            }

            bool IsFullHouse(bool addScore = true)
            {
                var gps = this.GroupBy(c => c.Value);
                var three = gps.FirstOrDefault(g => g.Count() == 3);
                var two = gps.FirstOrDefault(g => g.Count() == 2);
                if (three != null
                    &&
                    two != null)
                {
                    if (addScore)
                    {
                        Score.Add(7);
                        Score.Add(three.Key);
                        Score.Add(two.Key);
                    }

                    return true;
                }

                return false;
            }

            bool IsFlush(bool addScore = true)
            {
                if (this.GroupBy(c => c.suit).FirstOrDefault(g => g.Count() == 5)!=null)
                {
                    if (addScore)
                    {
                        Score.Add(6);
                        for (int i = Count - 1; i >= 0; i--)
                        {
                            Score.Add(this[i].Value);
                        }
                    }

                    return true;
                }
                return false;
            }

            bool IsStraight(bool addScore = true)
            {
                if (this[1].Value == this[0].Value + 1
                    && this[2].Value == this[1].Value + 1
                    && this[3].Value == this[2].Value + 1
                    && this[4].Value == this[3].Value + 1)
                {
                    if (addScore)
                    {
                        Score.Add(5);
                        for (int i = Count - 1; i >= 0; i--)
                        {
                            Score.Add(this[i].Value);
                        }
                    }

                    return true;
                }

                return false;
            }

            bool IsThree(bool addScore = true)
            {
                var gps = this.GroupBy(c => c.Value);
                var three = gps.FirstOrDefault(g => g.Count() == 3);

                if (three != null)
                {
                    if (addScore)
                    {
                        Score.Add(4);
                        Score.Add(three.Key);
                        var singles = gps.ToList().FindAll(g => g.Count() == 1);
                       
                        for (int i = singles.Count - 1; i >= 0; i--)
                        {
                            Score.Add(singles[i].Key);
                        }
                    }

                    return true;
                }
                return false;
            }

            bool IsTwoPair(bool addScore = true)
            {
                var s = this.GroupBy(c => c.Value).ToList();
                var pairs = s.FindAll(g => g.Count() == 2);
                if (pairs.Count == 2)
                {
                    if (addScore)
                    {
                        Score.Add(3);
                        Score.Add(pairs[1].Key);
                        Score.Add(pairs[0].Key);
                        var single = s.FindAll(g => g.Count() == 1);
                        Score.Add(single[0].Key);
                    }

                    return true;
                }

                return false;
            }

            bool IsPair(bool addScore = true)
            {
                var s = this.GroupBy(c => c.Value).ToList();
                var pairs = s.FindAll(g => g.Count() == 2);
                if (pairs.Count == 1)
                {
                    if (addScore)
                    {
                        Score.Add(2);
                        Score.Add(pairs[0].Key);
                        var singles = s.FindAll(g => g.Count() == 1);
                        
                        for (int i = singles.Count - 1; i >= 0; i--)
                        {
                            Score.Add(singles[i].Key);
                        }
                    }

                    return true;
                }

                return false;
            }

            public void Highest(bool addScore = true)
            {
                if (addScore)
                    Score.Add(1);

                for (int i = Count - 1; i >= 0; i--)
                {
                    if(addScore)
                        Score.Add(this[i].Value);
                }
            }

            private double AbsScore
            {
                get
                {
                    string sc = Score[0].ToString()+'.';

                    for (int i = 1; i < Score.Count; i++)
                    {
                        if (Score[i] < 10)
                            sc += Score[i] < 10 ? "0" : "";
                        sc+= Score[i].ToString();
                    }

                    double.TryParse(sc, out double s);

                    return s;
                }
            }

            public int CompareTo(Hand other)
            {
                return AbsScore > other.AbsScore ? 1 : AbsScore < other.AbsScore ? -1 : 0;
            }
        }

        public static long Run()
        {
            long res = 0;
            var lines = File.ReadAllLines("Data\\p054_poker.txt");
            foreach (var line in lines)
            {
                Hand h1 = new Hand(line.Substring(0,14));
                Hand h2 = new Hand(line.Substring(15));

                if (h1.CompareTo(h2) == 1)
                    res++;
            }

            return res;
        }
    }
}

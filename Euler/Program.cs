using System;
using System.Linq;
using Euler.Lib;
using Euler.Solutions;

namespace Euler
{
    class Program
    {    

        static void Main(string[] args)
        {
            //Console.WriteLine(new _191().Run(3));
            Console.WriteLine(new _59().Run());
            //Console.WriteLine(new _191().Run(5));
            //Console.WriteLine(new _191().Run(6));
            //Console.WriteLine(new _191().Run(7));
            //Console.WriteLine(new _191().Run(8));
            //Console.WriteLine(new _191().Run(9));
            //Console.WriteLine(new _191().Run(10));
            //System.IO.File.AppendAllText("C:\\STUFF\\12.txt", _13(numbers));
            Console.ReadKey();
            return;
            long l = 645;
            var x = l.GetPrimeFactorisation();//.Distinct();

            int c = 0;

            while (c < 5)
            {
                l++;
                if (l.GetPrimeFactorisation().Distinct().Count() == 4)
                {
                    c++;
                    if (c == 4)
                        break;
                }
                else c = 0;
            }

            var res = l - 4;
            
        }
    }
}

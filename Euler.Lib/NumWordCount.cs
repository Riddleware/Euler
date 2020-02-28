namespace Euler.Lib
{

    public class NumWordCount
    {
        public static int Count(int num)
        {
            var ret = 0;
            var t = num / 1000;
            if (t > 0)
            {
                ret += Count(t) + "Thousand".Length;
                num -= t * 1000;
            }

            var h = num / 100;
            if (h > 0)
            {
                ret += Count(h) + "Hundred".Length;// + t>0?3:0;
                num -= h * 100;
            }

            var d = num / 10;
            ret += (d > 0 || num > 0 )&& h > 0 ? 3 : 0;
            //if (d > 1)
            {
                ret += GetDec(num);
              //  num -= h * 10;
            }
            
            
            return ret;
        }

        static int GetDec(int n)
        {
            int ret = 0;

            switch (n/10)
            {
                case 9:                
                case 3:
                case 2:
                case 8:
                    ret = 6;
                    break;
                case 7:
                    ret = 7;
                    break;
                case 6:
                case 5:
                case 4:
                    ret = 5;
                    break;
                case 1:
                    switch (n)
                    {
                        case 19:
                        case 14:
                        case 13:
                        case 18:
                            ret = 8;
                            break;
                        case 17:
                            ret = 9;
                            break;
                        case 16:
                        case 15:
                            ret = 7;
                            break;
                        case 12:
                        case 11:
                            ret = 6;
                            break;
                        case 10:
                            ret = 3;
                            break;
                    }
                    break;
                case 0:
                    switch (n%10)
                    {
                        case 1:
                        case 2:
                        case 6:
                            ret = 3;
                            break;
                        case 4:
                        case 5:
                        case 9:
                            ret = 4;
                            break;
                        case 3:
                        case 8:
                        case 7:
                            ret = 5;
                            break;
                    }
                    break;
            }

            if (n / 10 > 1)
            {
                switch (n % 10)
                {
                    case 1:
                    case 2:
                    case 6:
                        ret += 3;
                        break;
                    case 4:
                    case 5:
                    case 9:
                        ret += 4;
                        break;
                    case 3:
                    case 8:
                    case 7:
                        ret += 5;
                        break;
                }
            }
            
            return ret;
        }

        ////////////////////////////////
        /// //////////////////////////////////
        public static string GetAsWord(int num)
        {
            var ret = "";
            var t = num / 1000;
            if (t > 0)
            {
                ret += GetAsWord(t) + "Thousand";
                num -= t * 1000;
            }

            var h = num / 100;
            if (h > 0)
            {
                ret += GetAsWord(h) + "Hundred";// + t>0?3:0;
                num -= h * 100;
            }

            var d = num / 10;
            ret += (d > 0 || num > 0) && h > 0 ? "And" : "";
            //if (d > 1)
            {
                ret += GetDecWord(num);
                //  num -= h * 10;
            }


            return ret;
        }

        static string GetDecWord(int n)
        {
            string ret = "";

            switch (n / 10)
            {
                case 9:
                    ret += "Ninety";
                    break;
                case 4:
                    ret += "Forty";
                    break;
                case 3:
                    ret += "Thirty";
                    break;
                case 2:
                    ret += "Twenty";
                    break;
                case 8:
                    ret += "Eighty";
                    break;
                case 7:
                    ret += "Seventy";
                    break;
                case 6:
                    ret += "Sixty";
                    break;
                case 5:
                    ret += "Fifty";
                    break;
                case 1:
                    switch (n)
                    {
                        case 19:
                            ret += "Nineteen";
                            break;
                        case 14:
                            ret += "Fourteen";
                            break;
                        case 13:
                            ret += "Thirteen";
                            break;
                        case 18:
                            ret += "Eighteen";
                            break;
                        case 17:
                            ret += "Seventeen";
                            break;
                        case 16:
                            ret += "Sixteen";
                            break;
                        case 15:
                            ret += "Fifteen";
                            break;
                        case 12:
                            ret += "Twelve";
                            break;
                        case 11:
                            ret += "Eleven";
                            break;
                        case 10:
                            ret += "Ten";
                            break;
                    }
                    break;
                case 0:
                    switch (n % 10)
                    {
                        case 1:
                            ret += "One";
                            break;
                        case 9:
                            ret += "Nine";
                            break;
                        case 4:
                            ret += "Four";
                            break;
                        case 3:
                            ret += "Three";
                            break;
                        case 2:
                            ret += "Two";
                            break;
                        case 8:
                            ret += "Eight";
                            break;
                        case 7:
                            ret += "Seven";
                            break;
                        case 6:
                            ret += "Six";
                            break;
                        case 5:
                            ret += "Five";
                            break;
                    }
                    break;
            }

            if (n / 10 > 1)
            {
               
                switch (n % 10)
                {
                    case 1:
                        ret += "One";
                        break;
                    case 9:
                        ret += "Nine";
                        break;
                    case 4:
                        ret += "Four";
                        break;
                    case 3:
                        ret += "Three";
                        break;
                    case 2:
                        ret += "Two";
                        break;
                    case 8:
                        ret += "Eight";
                        break;
                    case 7:
                        ret += "Seven";
                        break;
                    case 6:
                        ret += "Six";
                        break;
                    case 5:
                        ret += "Five";
                        break;
                }
            }

            return ret;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        private static Dictionary<int, Int64> values = new Dictionary<int, Int64>();

        static void Main(string[] args)
        {
            Console.WriteLine("hello fibonacci");

            var firstAbove = 1000;
            var count = 1000;
            var startValue = FiboStart(firstAbove);
            var startIndex = values.Keys.Where(i => values[i] == startValue).FirstOrDefault();
            var endIndex = startIndex + count - 1;
            Fibo(endIndex);
            var result = 0;// values.Values.Sum();

            Console.WriteLine("The first above {0}: {1}-{2}", firstAbove, startIndex, startValue);
            Console.WriteLine("The sum of 1000 numbers which above {0}: {1}", firstAbove, result);
        }

        static Int64 FiboStart(int n)
        {
            Int64 nNum = 0;
            var i = 0;
            while(true)
            {
                nNum = Fibo(i);
                if (nNum >= n)
                {
                    return nNum;
                }
                i++;
            }
        }

        static Int64 Fibo(int n)
        {

            Int64 returnValue = 0;

            if (values.TryGetValue(n, out returnValue))
            {
                return returnValue;
            }

            if (n == 0) returnValue = 0;
            else if (n == 1) returnValue = 1;
            else
                returnValue = Fibo(n - 1) + Fibo(n - 2);

            values.Add(n, returnValue);
            return returnValue;
        }
    }
}

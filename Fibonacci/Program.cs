using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
 
    class Program
    {
        private static Dictionary<int, double> values = new Dictionary<int, double>();
        const int FirstAbove = 1000;
        const int Count = 1000;

        static void Main(string[] args)
        {
            Console.WriteLine("hello fibonacci");

            var startValue = FiboStart(FirstAbove);
            var startIndex = values.Keys.FirstOrDefault(i => values[i] == startValue);
            var endIndex = startIndex + Count - 1;
            Fibo(endIndex);
            var result = values.Values.Where(i => i >= startValue).Sum();

            Console.WriteLine("The first above {0}: {1}-{2}", FirstAbove, startIndex, startValue);
            Console.WriteLine("The last number: {0}-{1}", values.Keys.LastOrDefault(), values.Values.LastOrDefault());
            Console.WriteLine("The sum of 1000 numbers which above {0}: {1}", FirstAbove, result);
        }

        static double FiboStart(double n)
        {
            double nNum = 0;
            var i = 0;
            while (true)
            {
                nNum = Fibo(i);
                if (nNum >= n)
                {
                    return nNum;
                }
                i++;
            }
        }

        static double Fibo(int n)
        {

            double returnValue = 0;

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

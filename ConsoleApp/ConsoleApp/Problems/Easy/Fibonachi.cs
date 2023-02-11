using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Easy
{
    internal class Fibonachi
    {
        public static void Run()
        {
            Console.WriteLine("=============== Fibonachi ==================");

            PrintFibonachiR(10);
        }


        private static void PrintFibonachi(int count)
        {
            int result = 0;

            int start = 0;
            int next = 1;

            int i = 0;
            while (i < count)
            {
                var localSum = start + next;
                result+=localSum;

                (start, next) = (next, localSum);

                i++;

                Console.WriteLine(localSum);
            }
        }


        public static void PrintFibonachiR(int count)
        {
            PrintFibonachiRInternal(0, 1, 0, count);


        }

        private static void PrintFibonachiRInternal(int prev, int next, int counter, int count)
        {
            if(counter > count)
                return;

            PrintFibonachiRInternal(next, prev+next, ++counter, count);

            Console.WriteLine(prev);
        }
    }
}

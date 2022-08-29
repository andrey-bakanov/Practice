using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal static class FizzBuzz
    {

        public static void Run()
        {
            DoRun2();               
            
        }


        public static void DoRun1()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i < 3)
                {
                    Console.WriteLine(i);
                    continue;
                }
                int result3 = i % 3;
                int result5 = i % 5;

                if (result3 == 0 && result5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (result3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (result5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }

            }
        }

        public static void DoRun2()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i < 3)
                {
                    Console.WriteLine(i);
                    continue;
                }

                if (i % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }

            }
        }
    }
}

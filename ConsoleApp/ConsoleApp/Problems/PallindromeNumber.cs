using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal class PallindromeNumber
    {

        public static void Run()
        {
            int result1 = 12321;
            Console.WriteLine($"{result1} " + IsPallindrome(result1));

            int result2 = 123215;
            Console.WriteLine($"{result2} " + IsPallindrome(result2));
        }


        public static bool IsPallindrome(int number)
        {
            if(number < 10)
            {
                return false;
            }

            if(number % 10 == 0)
            {
                return false;
            }

            List<int> array = new List<int>(10);
            var quot = Math.DivRem( number, 10, out int rem);
            while(quot > 0)
            {
                array.Add(rem);
                if (quot < 10)
                {
                    array.Add(quot);
                    break;
                }
                
                quot = Math.DivRem(quot, 10, out rem);
            }

            int i = 0;
            int j = array.Count - 1;
            while(i < j)
            {
                if (array[i++] != array[j--])
                    return false;
            }


            return true;
        }
    }
}

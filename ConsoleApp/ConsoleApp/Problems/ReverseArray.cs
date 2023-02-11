using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal static class ReverseArray
    {
        internal static void Run()
        {
            Console.WriteLine("============= ReverseArray ================");
            var array = new int[] {1,3,4,7,8,9,4,3 };

            Reverse(array);
            var result = new int[] { 1, 3, 4, 7, 8, 9, 4, 3 }.Reverse().SequenceEqual(array);
            
            Console.WriteLine(result);

        }


        private static void Reverse(int[] array)
        {
            if (array == null)
                return;

            if (array.Length < 2)
                return;

            int left = 0;
            int right = array.Length - 1;

            while(left < right)
            {

                (array[left], array[right]) = (array[right], array[left]);

                left++;
                right--;
            }
        }
    }
}

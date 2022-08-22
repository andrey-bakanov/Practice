using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.Searching
{
    internal static class BinarySearch
    {
        public static void Run()
        {
            int[] array = ArrayHelper.GetShortSortedHardcodedArray();

            var @index = DoBinarySearch(array, 5);

            Console.WriteLine($"result={@index}");
        }

        private static int DoBinarySearch(int[] array, int target)
        {
            int result = -1;

            int startIndex = 0;
            int endIndex = array.Length - 1;

            while (startIndex < endIndex)
            {
                int middle = (endIndex - startIndex)/2;
                if (array[middle] == target)
                {
                    return middle;
                }
                else if (array[endIndex] > target)
                {
                    startIndex = middle;
                }
                else
                {
                    endIndex = middle;
                }
            }

            return result;
        }
    }
}

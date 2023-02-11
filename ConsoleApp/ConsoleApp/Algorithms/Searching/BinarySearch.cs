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

            var @index2 = DoBinarySearch2(array, 0, array.Length - 1, 5);

            Console.WriteLine($"result={@index}  {index2}");
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


        private static int DoBinarySearch2(int[] array, int startIndex, int endIndex, int target)
        {
            if (startIndex > endIndex)
            { 

                return -1;
            }

            if (startIndex == endIndex)
            {
                if (array[startIndex] == target)
                    return startIndex;

                return -1;
            }

            int middleIndex = endIndex - (endIndex-startIndex) /2;

            int middleValue = array[middleIndex];

            if(middleValue == target)
                return middleIndex;
            else if (array[middleIndex] > target)
            {
                return DoBinarySearch2(array, startIndex, middleIndex-1, target);
            }
            else
            {
                return DoBinarySearch2(array, middleIndex + 1, endIndex, target);
            }


        }
    }
}

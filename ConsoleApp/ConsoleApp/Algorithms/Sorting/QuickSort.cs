using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.Sorting
{
    /*
     *  QuickSort agorithm
     * 
     */
    internal class QuickSort
    {
        public static void Run()
        {
            int[] array = new int[] { 1,5,3,7,4,9,5,3,4,90, 6, 15};
            
            Sort(array, 0, array.Length-1);

            Console.WriteLine( JsonSerializer.Serialize(array) );
        }


        public static void Sort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int pivotIndex = Partition(array, startIndex, endIndex);

                Sort(array, startIndex, pivotIndex - 1);
                Sort(array, pivotIndex + 1, endIndex);
            }

        }

        public static int Partition(int[] array, int startIndex, int endIndex)
        {
            int pivot = array[endIndex];

            int index = startIndex;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (array[i] < pivot)
                {
                    (array[index], array[i]) = (array[i], array[index]);
                    index++;
                }


            }
            (array[index], array[endIndex]) = (array[endIndex], array[index]);
            return index;
        }



    }
}

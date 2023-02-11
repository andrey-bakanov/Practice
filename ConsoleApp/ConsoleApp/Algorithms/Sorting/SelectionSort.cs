using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.Sorting
{
    internal class SelectionSort
    {

        public static void Run()
        {

            Console.WriteLine("=============== SelectionSort =======================");

            int[] array = new int[] {20,3,7,12,5,9,7,5,1,17,2 };

            var result = DoSelectionSort(array);


            Console.WriteLine(JsonSerializer.Serialize(result));
        }

        private static int[] DoSelectionSort(int[] array)
        {
            int[] result = new int[array.Length];

            return result;
        }
    }
}

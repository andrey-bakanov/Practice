using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    /// <summary>
    /// O(n) and without extra space
    /// </summary>
    internal class FindAllDuplicatesInArray
    {

        internal static void Run()
        {
            Console.WriteLine("================== FindAllDuplicatesInArray ===============");

            //O(n^2) loop in loop
            //O(n*log n)   loop and binary search
            int[] array = new int[] { 1, 2000, 3, 4, 5, 4, 6, 7, 7, 8, 9, 12};// -> 4, 7

                                   // 1  3  6  10 15 19 25 32 39 47 56 56
                                   // 0
                                   // 
            var result = FindAllDuplicates(array);
            Console.WriteLine(JsonSerializer.Serialize(result));

            var result2 = FindAllDuplicates2(array);
            Console.WriteLine(JsonSerializer.Serialize(result));
        }

        private static List<int> FindAllDuplicates(int[] array)
        {
            List<int> result = new List<int>(array.Length);

            QuickSort(0, array.Length-1, array);

            Console.WriteLine("The repeating elements are : ");
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i-1] == array[i])
                {
                    result.Add(array[i]);
                }
            }

            return result;
        }

        private static void QuickSort(int start, int end, int[] array)
        {
            if (start < end)
            {
                int middle = GetBaseIndex(0, end, array);


                QuickSort(0, middle - 1, array);
                QuickSort(middle + 1, end - 1, array);
            }
        }

        private static int GetBaseIndex(int start, int end, int[] array)
        {
            int baseElement = array[end];
            int pos = end;
            for(int i=start; i < end; i++)
            {
                if(array[i] > baseElement)
                {
                    (array[pos], array[i]) = (array[i], array[pos]);
                    pos++;
                }
            }

            return pos;
        }


        private static IEnumerable<int> FindAllDuplicates2(int[] array)
        {
            List<int> result = new List<int>(array.Length);

            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (int c in array)
            {
                if(map.TryGetValue(c, out int count ))
                {
                    map[c] = ++count;
                }
                else
                {
                    map[c] = 1;
                }
            }

            foreach (var pair in map)
                if (pair.Value > 1)
                    yield return pair.Key;


        }
    }
}

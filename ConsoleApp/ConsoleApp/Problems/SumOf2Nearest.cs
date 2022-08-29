using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal class SumOf2Nearest
    {
		public static void Run()
		{
			int[] array = new[] { 1, 21, 3, 9, 6, 12, 11, 2 };
			int target = 16; //nearest sum 17 11+6 or 15 9+6

			Stopwatch sw = Stopwatch.StartNew();

			quickSort(array, 0, array.Length-1);

			Console.WriteLine( JsonConvert.SerializeObject(array));

			int[] resultArray = SumOfTwo(array, target);

			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds + " -> " + JsonConvert.SerializeObject(resultArray));
		}


		private static int[] SumOfTwo(int[] array, int target)
		{
			int[] result = new int[2];

			int currentDiff = Math.Abs(target - ( array[0] + array[1]) );

			int i = 0;
			int j = array.Length - 1;
			while(i < j)
            {
				var currentLeft = array[i];
				var currentRight = array[j];
				var localdiff = Math.Abs( target - (currentLeft + currentRight));
				if(localdiff < currentDiff)
                {
					currentDiff  = localdiff;
					result[0] = i;
					result[1] = j;

					i++;

				}
				else
                {
					j--;
                }
				

            }


			return result;
		}

		private static void quickSort(int[] array, int startIndex, int endIndex)
        {
			if (startIndex < endIndex)
			{
				int baseElement = GetBaseElement(array, startIndex, endIndex);


				quickSort(array, startIndex, baseElement-1);
				quickSort(array, baseElement+1, endIndex);
			}
		}

		private static int  GetBaseElement(int[] array, int startIndex, int endIndex)
        {
			var result = array[endIndex];
			var j  = startIndex;
			for(int i = startIndex; i <endIndex; i++)
            {
				if(array[i] < result)
                {
					Swap(array, j, i);
					j++;
                }
            }

			Swap(array, j, endIndex);
			return j;
        }

		private static void Swap(int[] array, int i, int j)
        {
            (array[j], array[i]) = (array[i], array[j]);
        }
    }
}

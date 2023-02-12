using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal class SumOf2
    {

		public static void Run()
		{
			int[] array = new[] { 1, 2, 4, 3, 6 };
			int target = 5;

			Stopwatch sw = Stopwatch.StartNew();
			int[] resultArray = SumOfTwo(array, target);

			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds +  " -> " + JsonSerializer.Serialize(resultArray));
		}


		public static int[] SumOfTwo(int[] array, int target)
		{
			int[] result = new int[2];

			Dictionary<int, int> hashMap = new Dictionary<int, int>();
			for (int i = 0; i < array.Length; i++)
			{
				hashMap[array[i]] = i;
			}

			for (int i = 0; i < array.Length; i++)
			{
				int current = array[i];

				int need = target - current;
				int needIndex = hashMap.GetValueOrDefault(need, -1);
				if (needIndex >= 0)
				{
					result[0] = needIndex;
					result[1] = i;

					break;
				}
			}

			return result;
		}
	}
}

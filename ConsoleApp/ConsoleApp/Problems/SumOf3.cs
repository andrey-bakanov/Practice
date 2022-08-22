using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace ConsoleApp.Problems
{
    internal class SumOf3
    {

		public static void Run()
		{
			int[] array = new int[] { 1, 2, 4, 7, 3, 2, 5 };
			int target = 10;

			int[] result = SumOfThree(array, target);

			Console.WriteLine(JsonConvert.SerializeObject(result));
		}


		public static int[] SumOfThree(int[] array, int target)
		{
			int[] result = new int[3];

			for (int i = 0; i < array.Length; i++)
			{
				int current = array[i];

				int startIndex = i;
				int endIndex = array.Length;

				int localTarget = target - current;
				while (startIndex < endIndex)
				{
					var elementsSum = array[startIndex] + array[endIndex];
					if (elementsSum == localTarget)
					{ 
						return new int[] { i, startIndex, endIndex };
					}

					if(localTarget < elementsSum)
						startIndex++;
					else
						endIndex--;
				}
			}

			return result;
		}
	}




}

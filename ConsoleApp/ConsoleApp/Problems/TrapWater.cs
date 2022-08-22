using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal static class TrapWater
    {

		public static void Run()
		{
			int[] array = new int[] { 1, 2, 3, 0, 2, 1, 2 };
								//  { 0, 1, 1, 3, 1, 2, 1 };
			//
			int result = DoTrapWater(array);

			Console.WriteLine($"result={result}");
		}

		private static int DoTrapWater(int[] array)
        {
			int result = 0;
			int prevMax = 0;
			int serieLength = 0;
			bool direction = true;

			for(int i =0; i < array.Length; i++)
            {
				//идем направо и накапливаем
				if (array[i] >= prevMax && direction)
				{
					prevMax = array[i];
				}
				else if (array[i] < prevMax && direction)
				{
					//переломный момент - идем вниз
					direction = false;
					serieLength = 1;
					result += prevMax - array[i];
				}
				else if (array[i] > prevMax && !direction)
				{
					serieLength++;
					result += prevMax - array[i];
					prevMax = array[i];
					serieLength = 0;
					direction = true;

				}
				else if (array[i] <= prevMax && !direction)
				{
					serieLength++;
					result += prevMax - array[i];
				}

				if(i == array.Length - 1)
                {
					if(array[i] <= prevMax);

				}

				Console.WriteLine($"i={i}; a[i]={array[i]}; result={result}; prevMax={prevMax}; serieLength={serieLength}");
			}

			return result;
        }
	}
}

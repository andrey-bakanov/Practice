using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
			int leftMax = 0;
			int rightMax = 0;

			int[] maxLeftItems = new int[array.Length];
			int[] maxRightItems = new int[array.Length];
			int[] items = new int[array.Length];
			for (int i = 1; i < array.Length; i++)
            {
				int current = array[i];
				int localresult = 0; ;

				if (current >= leftMax )
				{
					leftMax = current;
				}
				else if (current < leftMax )
				{
					localresult = leftMax - current;
				}
				maxLeftItems[i] = localresult;

				localresult = 0;
				int j = array.Length - i;
				int currentRight = array[j];

				if (currentRight >= rightMax)
				{
					rightMax = currentRight;
				}
				else if (currentRight < rightMax)
				{
					localresult = rightMax - currentRight;
				}
				maxRightItems[j] = localresult;

				

				Console.WriteLine($"i={i}; a[i]={array[i]}; result={result}; prevMax={leftMax};");
			}

			for (int i = 1; i < array.Length; i++)
			{
				items[i] = Math.Min(maxLeftItems[i], maxRightItems[i]);
			}

			Console.WriteLine(JsonSerializer.SerializeToNode(maxLeftItems).ToJsonString());
			Console.WriteLine(JsonSerializer.SerializeToNode(maxRightItems).ToJsonString());
			Console.WriteLine(JsonSerializer.SerializeToNode(items).ToJsonString());
			return items.Sum();
        }

		private static int DoTrapWater2(int[] array)
		{
			int result = 0;
			int leftMax = 0;
			int rightMax = 0;

			return result;
		}
	}
}

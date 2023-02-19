using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal static class NearestGreatest
    {
        public static void Run()
        {
            int[] array = new[] { 1, 3, 2, 1 , 4, 3, 2, 6, 5, 1, 4, 12, 4 };

            Stopwatch sw = Stopwatch.StartNew();
            int[] resultArray = GetNearestGreatests(array);

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds + " -> " + JsonSerializer.Serialize(array));
            Console.WriteLine(sw.ElapsedMilliseconds + " -> " + JsonSerializer.Serialize(resultArray));
        }

        public static int[] GetNearestGreatests(int[] array)
        {
            int[] result = new int[array.Length];

            
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(array[array.Length - 1]);
            for (int i = array.Length-2; i >= 0; i--)
            {
                var prev = stack.Peek();
                var current = array[i];
                if (prev > current)
                {
                    result[i] = prev;
                    stack.Push(current);
                }
                else
                {
                    while(stack.Count > 0)
                    {
                        var stackValue = stack.Peek();
                        if(stackValue > current)
                        {
                            result[i] = stackValue;
                            break;
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                    stack.Push(current);
                }
            }

            return result;
        }

    }
}

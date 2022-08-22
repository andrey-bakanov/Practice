using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    /*
     *  Find a max sequence of 1 in array. Only 0 and 1 possible
     * 
     * 
     */
    internal class SequenceOf1
    {

        public static void Run()
        {
            int[] array = new int[] { 0,1, 0, 0,1,1,1,0,1,1,0,0,1,1,1,1 };

            var result = Find(array);

            Console.WriteLine("SequenceOf1 = " + result);
        }


        private static int Find(int[] array)
        {
            int result = 0;
            int localResult = 0;
            for (int i= 1; i < array.Length; i++)
            {                
                if (array[i] == 1)
                {
                    localResult++;
                }
                else
                {
                    if (localResult > result)
                    { 
                        result = localResult;
                    }
                    localResult = 0;
                }
            }

            if (localResult > result)
            {
                result = localResult;
            }
            return result;

        }
    }
}

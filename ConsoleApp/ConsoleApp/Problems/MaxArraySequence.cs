using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    /// <summary>
    /// Сумма непрерывного массива без повторений
    /// </summary>
    internal static class MaxArraySequence
    {
        public static void Run()
        {

            Console.WriteLine("============ MaxArraySequence =================");

            var array = new int[] { 1,2,4,8,2,4,6,2,3,6}; //5

            int result = Sequence3(array);

            Console.WriteLine($"result = {result}");
        }

        /// <summary>
        /// Длина непрерывного массива
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Sequence(int[] array)
        {
            if (array == null)
                return 0;

            if (array.Length == 0)
                return 0;

            if(array.Length == 1)
                return array[0];

            int result = 0;
            List<int> sequence = new List<int>(array.Length);

            for(int i=0; i < array.Length; i++)
            {
                bool endSequence = false;
                for(int j = 0; j < sequence.Count; j++)
                {
                    if(array[i] == sequence[j])
                    {
                        if(sequence.Count > result)
                        {
                            result = sequence.Count;
                        }
                        endSequence = true;
                    }
                }

                if (endSequence)
                {
                    sequence.Clear();
                    sequence.Add(array[i]);

                    endSequence = false;
                }
                else 
                {
                    sequence.Add(array[i]);
                }
            }


            return result;
        }

        /// <summary>
        /// Подмассив последовательности
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Sequence2(int[] array)
        {
            if (array == null)
                return 0;

            if (array.Length == 0)
                return 0;

            if (array.Length == 1)
                return array[0];

            int result = 0;
            int startIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = startIndex; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        if ((i - startIndex) > result)
                        {
                            result = (i - startIndex);
                        }
                        startIndex = i;
                    }
                }
            }


            return result;
        }


        /// <summary>
        /// Подмассив последовательности
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Sequence3(int[] array)
        {
            if (array == null)
                return 0;

            if (array.Length == 0)
                return 0;

            if (array.Length == 1)
                return array[0];

            int result = 0;

            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < array.Length; i++)
            {
                int startIndex = i;
                for (int j = startIndex; j < array.Length; j++)
                {
                    if ( dictionary.ContainsValue( array[j] ))
                    {
                        if ((j - startIndex) > result)
                        {
                            result = (j - startIndex);
                        }
                        startIndex = j;

                        dictionary.Clear();
                        dictionary.Add(j, array[j]);
                    }
                    else
                    {
                        dictionary.Add(j, array[j]);
                    }
                }
            }


            return result;
        }
    }
}

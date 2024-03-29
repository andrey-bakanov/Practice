﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static  class ArrayHelper
    {
        static Random rnd = new Random();

        public static int[] GetRandomArray(int length)
        {
            int[] result = new int[length];
            for(int i = 0; i < length; i++)
            {
                result[i] = rnd.Next(0, 99);
            }
            return result;
        }

        public static int[] GetShortUnsortedHardcodedArray()
        {
            return new int[] {4,7,1,3,17,3,6,15,11,5 };
        }

        public static int[] GetShortSortedHardcodedArray()
        {
            return new int[] { 1, 3, 4, 5, 7, 10, 13, 17, 19, 27 };
        }

        public static void Dump(int[] array)
        {
            Console.WriteLine( JsonSerializer.Serialize(array) );
        }

        public static void Dump(int[,] array)
        {
            for(int i= 0; i < array.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{ (j > 0 ? ", " : "") }" + array[i, j]);
                }
                Console.WriteLine("]");
            }
        }
    }
}

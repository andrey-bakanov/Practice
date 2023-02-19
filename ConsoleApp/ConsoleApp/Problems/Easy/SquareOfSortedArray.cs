using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Easy
{

    /*
     Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.
     
    Input: nums = [-4,-1,0,3,10]
    Output: [0,1,9,16,100]
    Explanation: After squaring, the array becomes [16,1,0,9,100].
    After sorting, it becomes [0,1,9,16,100].

    Input: nums = [-7,-3,2,3,11]
    Output: [4,9,9,49,121]
    
     */
    internal class SquareOfSortedArray
    {
        public void Execute()
        {
            Console.WriteLine("===========SquareOfSortedArray===============");

            int[] a = new int[] { -4, -1, 0, 3, 10 };

            var result = Do2(a);
            ArrayHelper.Dump(result);

            a = new int[] {-7, -3, 2, 3, 11};

            result = Do2(a);
            ArrayHelper.Dump(result);
        }


        public int[] Do(int[] input)
        {
            int[] result = new int[input.Length];

            if (input[0] > 0)
            {
                for(int i=0; i<input.Length; i++)
                {
                    result[i] = input[i]* input[i];
                }
            }
            else
            {
                int resultIndex = 0;
                Stack<int> squares = new Stack<int>();
                for (int i = 0; i < input.Length; i++)
                {
                    var pivotValue = input[i] * input[i];
                    if (input[i] < 0)
                    {
                        squares.Push(pivotValue);
                    }
                    else
                    {
                        while(squares.Count > 0) 
                        {
                            int sq = squares.Peek();
                            if (sq <= pivotValue)
                            {
                                result[resultIndex] = sq;
                                resultIndex++;
                                squares.Pop();
                            }
                            else
                                break;
                        }

                        result[resultIndex] = pivotValue;
                        resultIndex++;
                    }
                }

            }

            return result;
        }

        public int[] Do2(int[] input)
        {
            int[] result = new int[input.Length];

            int pivotIndex = 0;
            int pivotValue = Math.Abs( input[pivotIndex] );

            for (int i = 0; i < input.Length; i++)
            {
                if (Math.Abs(input[i]) < pivotValue)
                {
                    pivotIndex = i;
                    pivotValue = Math.Abs(input[i]);
                }
            }

            result[0] = pivotValue * pivotValue;
            int resultIndex = 1;

            int leftIndex = pivotIndex -1;
            int rightIndex = pivotIndex + 1;

            while(leftIndex >= 0 || rightIndex < input.Length)
            {

                if (leftIndex >= 0 && rightIndex < input.Length)
                {
                    var left = Math.Abs(input[leftIndex]) ;
                    var right = Math.Abs(input[rightIndex]);

                    if (left >= right && rightIndex < input.Length)
                    {
                        result[resultIndex] = right * right;
                        resultIndex++;
                        rightIndex++;
                    }
                    else if (leftIndex >= 0)
                    {
                        result[resultIndex] = left* left;
                        resultIndex++;
                        leftIndex--;
                    }
                }
                else if (leftIndex >= 0)
                {
                    var left = Math.Abs(input[leftIndex]);
                    result[resultIndex] = left * left;
                    resultIndex++;
                    leftIndex--;
                }
                else if(rightIndex < input.Length)
                {
                    var right = Math.Abs(input[rightIndex]);

                    result[resultIndex] = right * right;
                    resultIndex++;
                    rightIndex++;
                }

            }

            return result;
        }
    }
}

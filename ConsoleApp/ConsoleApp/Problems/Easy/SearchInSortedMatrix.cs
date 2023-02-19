using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Easy
{
    /*
     * OZON
     we have  matrix [
                        [1,  3,  7]
                        [9,  11, 15]
                        [12, 13, 17
                    ]
    sorted by rows and columns. Write a funtion to find a specific value 
    input 3 - output true
    input 5 - output false
     */
    internal class SearchInSortedMatrix
    {
        public void Execute()
        {
            int[,] matrix = new int[,] {
                {1, 3, 7 } ,
                {9, 11, 15 } ,
                {17, 19, 25 } ,
            };

            var result = Find(matrix, 5);

            Console.WriteLine($"SearchInSortedMatrix={result}");

        }

        private bool Find(int[,] matrix, int target)
        {
            int size = matrix.GetLength(0) * matrix.GetLength(1);//9

            int startIndex = 0;
            int endIndex = size - 1;

            while(startIndex < endIndex)
            {
                int midIndex = (endIndex - startIndex) / 2; //4

                int rowIndex = midIndex / matrix.GetLength(0); // 1
                int colIndex = midIndex % matrix.GetLength(0);  // 1

                int midValue = matrix[rowIndex, colIndex]; // 9
                if(midValue > target)
                {
                    endIndex = midIndex;
                }    
                else if(midValue < target)
                {
                    startIndex = midIndex;
                }
                else
                {
                    return true;
                }

                if (midIndex == 0)
                {
                   break;
                }
            }


            return false;
        }
    }
}

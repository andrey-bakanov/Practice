using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Medium
{
    /*
     * OZON
     * 
     given a matrix with 0 or 1, where 0 - water and 1 - island
    island may be only on verticals or horisontals. Diagonals doesnot give a island
    Find a max square island
    [
        0, 0, 0, 1, 0, 0, 1, 0
        0, 1, 0, 1, 0, 0, 0, 1
        0, 0, 1, 0, 0, 0, 1, 1
        1, 1, 0, 0, 0, 0, 0, 0
        0, 0, 0, 1, 1, 1, 1, 0
        0, 0, 0, 1, 1, 0, 0, 0
    ]
    resuls is 6
     */
    internal class MatrixIslands
    {
        public void Execute()
        {
            Console.WriteLine("==================MatrixIslands===========");

            int[,] matrix = new int[,] {

                { 0, 0, 0, 1, 0, 0, 1, 0},
                { 0, 1, 0, 1, 0, 0, 0, 1},
                { 0, 0, 1, 0, 0, 0, 1, 1},
                { 1, 1, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 1, 1, 1, 0},
                { 0, 0, 0, 1, 1, 0, 0, 0}    
            };

            var result = Do (matrix);

            Console.WriteLine($"MatrixIslands={result}");
        }

        private int Do(int[,] matrix)
        {
            int result = 0;

            int currentSquare = 0;

            for(int i = 0; i< matrix.GetLength(0); i++)
            {
                for(int j = 0; j< matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0 || matrix[i, j] == -1)
                    {
                        continue;
                    }

                    currentSquare = Step(matrix, i, j);

                    if(currentSquare > result)
                    {
                        result = currentSquare;
                    }

                    ArrayHelper.Dump(matrix);
                }
            }

            return result;
        }

        private int Step(int[,] matrix, int i, int j)
        {
            Console.WriteLine($"-> {i}, {j}");
            if(i < 0 || j < 0)
                return 0;

            if (i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
                return 0;

            if(matrix[i, j] == 0 || matrix[i, j] == -1)
                return 0;

            matrix[i, j] = -1;

            return 1 + Step(matrix, i+1, j) + Step(matrix, i, j+1) + Step(matrix, i-1, j) + Step(matrix, i, j-1);
        }
    }
}

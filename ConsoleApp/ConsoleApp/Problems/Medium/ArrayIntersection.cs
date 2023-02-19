using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Medium
{
    internal class ArrayIntersection
    {
        /*
            написать функцию которая принимает 2 отсортированных массива целых чисел( числа могут повторяться) 
            и возвращает 2 массива - первый это объединение 2х массивов, но количество повторяющихся чисел должно быть не больше количества 
            в одном из входных массивов, и второй - это массив пересечения значений.
            Пример:
            Входящий 1й массив: 1,2,3,4,4,4,5,6,9,14,47
            Входящий 2й массив: 1,4,4,5,5,10,14,19
            Результат:
            Объединение*:1,2,3,4,4,4,5,5,6,9,10,14,19,47
            Пересечение:1,4,4,5,14
         */
        public void Execute()
        {
            var arr1 = new int[] { 1, 2, 3, 4, 4, 4, 5, 6, 9, 14, 47 };
            var arr2 = new int[] { 1, 4, 4, 5, 5, 10, 14, 19 };

            (int[] r1, int[] r2) = Do(arr1, arr2);

            ArrayHelper.Dump(r1);
            ArrayHelper.Dump(r2);

        }

        private (int[], int[]) Do(int[] a1, int[] a2)
        {
            int maxLength = Math.Max(a1.Length, a2.Length);

            List<int> list1 = new List<int>(a1.Length + a2.Length);
            List<int> list2 = new List<int>(maxLength);

            int i1 = 0;
            int i2 = 0;
            while(true)
            {
                if(i1 >= a1.Length)
                {
                    //copy second array to result array
                    while (i2 < a2.Length)
                    {
                        list1.Add(a2[i2]);
                        i2++;
                    }

                    break;
                }

                if (i2 >= a2.Length)
                {
                    //copy first array to result array
                    while (i1 < a1.Length)
                    {
                        list1.Add(a1[i1]);
                        i1++;
                    }
                    break;
                }

                var elem1 = a1[i1];
                var elem2 = a2[i2];
                if(elem1 > elem2)
                {
                    list1.Add(elem2);
                    i2++;
                }
                else if(elem1 < elem2)
                {
                    list1.Add(elem1);
                    i1++;
                }
                else
                {
                    var pivot = elem1;

                    while (elem1 == pivot || elem2 == pivot)
                    {
                        if(elem1 == pivot && elem2 == pivot)
                        {
                            list2.Add(pivot);
                            list1.Add(pivot);
                            i1++;
                            i2++;
                        }
                        else if(elem1 == pivot)
                        {
                            list1.Add(pivot);
                            i1++;
                        }
                        else if (elem2 == pivot)
                        {
                            list1.Add(pivot);
                            i2++;
                        }

                        elem1 = a1[i1];
                        elem2 = a2[i2];
                    }
                }
            }

            return (list1.ToArray(), list2.ToArray());
        }
    }
}

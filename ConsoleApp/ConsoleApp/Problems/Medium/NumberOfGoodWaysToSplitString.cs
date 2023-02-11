using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Medium
{
    /*
     
     Условие задачи:

        Имеется строка s на входе. Так вот, разделение этой строки на 2 непустые подстроки p и q называется хорошим тогда и только тогда, когда конкатенация этих строк дает строку s и количество различных элементов в подстроке p равно количеству различных в q.
        На выходе нужно вернуть количество "хороших" разделений строки s.

        Ограничения:

        s содержит элементы из множества ['a', 'b'...'z'].

        1 <= s.length <= 10^5

        Претесты:

        Input: s = "aacaba"
        Output: 2.
        Explanation: Исходную строку можно разбить 5ью разными способами
        в соответствии с условиями задачи:
        p = "a", q = "acaba" - не является "хорошей"
        p = "aa", q = "caba" - не является "хорошей"
        p = "aac", q = "aba" - является "хорошей"
        p = "aaca", q = "ba" - является "хорошей"
        p = "aacab", q = "a" - не является "хорошей"

        Input: s = "abcd"
        Output: 1.
        Explanation: p = "ab", q = "cd" - разбиение является "хорошим"
     
     
     */
    internal static class NumberOfGoodWaysToSplitString
    {
        public static void Run()
        {
            var s = "aacaba";

            Console.WriteLine($"Splits count: {s} " + GetNumberOfSplits(s));
        }

        private static int GetNumberOfSplits(string s) {

            int splitsCount = 0;

            int currentIndex = 0;
            int endIndex = s.Length - 2;

            var leftUniques = new Dictionary<char, int>();
            var rightUniques = new Dictionary<char, int>();

            foreach (char c in s) 
            {
                if (rightUniques.TryGetValue(c, out int count))
                {
                    rightUniques[c] = ++count;
                }
                else
                {
                    rightUniques.Add(c, 1);
                }
            }


            while (currentIndex <= endIndex)
            {
                var current = s[currentIndex];

                if(leftUniques.Count == rightUniques.Count)
                    splitsCount++;

                if(leftUniques.TryGetValue(current, out int leftCount))
                {
                    leftUniques[current] = ++leftCount;
                }
                else
                {
                    leftUniques.Add(current, 1);
                }

                if (rightUniques.TryGetValue(current, out int rightCount))
                {
                    if (rightCount == 1)
                    {
                        rightUniques.Remove(current);
                    }
                    else
                    {
                        rightUniques[current] = --rightCount;
                    }
                }

                currentIndex++;
            }



            return splitsCount;
        
        }
    }
}

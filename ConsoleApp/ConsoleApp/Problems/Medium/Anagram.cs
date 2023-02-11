using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Medium
{
    internal static class Anagram
    {

        public static void Run()
        {
            string test11 = "море";
            string test12 = "роме";


            Console.WriteLine("IsAnagram:" + test11 + " " + test12 + " = " + IsAnagram(test11, test12));
            Console.WriteLine("IsAnagram:" + test11 + " " + test12 + " = " + IsAnagram2(test11, test12));

            string test21 = "мореt";
            string test22 = "ромеe";


            Console.WriteLine("IsAnagram 2:" + test21 + " " + test22 + " = " + IsAnagram(test21, test22));
            Console.WriteLine("IsAnagram 2:" + test21 + " " + test22 + " = " + IsAnagram2(test21, test22));
        }

        private static bool IsAnagram(string str1, string str2)
        {
            if (str1 == str2)
                return false;

            if (str1.Length != str2.Length)
                return false;

            int[] alreadyProcessed = new int[str1.Length];
            int position = 0;

            var str2Array = str2.ToCharArray();

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2Array.Length; j++)
                {
                    if (str2Array[j] == '*')
                        continue;

                    if (str1[i] == str2Array[j])
                    {
                        str2Array[j] = '*';
                        break;
                    }
                }
            }

            for (int j = 0; j < str2Array.Length; j++)
            {
                if (str2Array[j] != '*')
                    return false;
            }

            return true;
        }


        private static bool IsAnagram2(string str1, string str2)
        {
            if (str1 == str2)
                return false;

            if (str1.Length != str2.Length)
                return false;


            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char current in str2)
            {
                if (charCount.TryGetValue(current, out int count))
                {
                    charCount[current] =  ++count;
                }
                else
                {
                    charCount.Add(current, 1);
                }
            }

            for(int i = 0; i < str1.Length; i++)
            {
                char current = str1[i];
                if (charCount.TryGetValue(current, out int count))
                {
                    if(count == 0)
                    {
                        return false;
                    }
                    else if(count == 1)
                    {
                        charCount[current] = 0;
                    }
                    else if (count > 1)
                    {
                        charCount[current] = --count;
                    }
                }
                else
                {
                    return false;
                }
            }

            foreach(var pair in charCount)
            {
                if (pair.Value != 0)
                    return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal static class PallindromeLongestSubstring
    {

        internal static void Run()
        {
            Console.WriteLine("============= PallindromeLongestSubstring ====================");

            //djdjaadaabbaooid -> aadaa

            string result = FindPallindrome("djdjaadaabbaooid");

            Console.WriteLine(result);

        }

        private static string FindPallindrome(string str)
        {
            if (str == null)
                return null;

            if (str.Length < 3)
                return str;


            string result = String.Empty;

            for(int i =0; i< str.Length; i++)
            {
                
                for(int j = (i+1); j < str.Length; j++)
                {
                    int startIndex = i;
                    int endIndex = j;

                    bool isPallindrome = true;
                    while(startIndex < endIndex)
                    {
                        if( str[startIndex] != str[endIndex] )
                        {
                            isPallindrome = false;
                            break;
                        }
                        startIndex++;
                        endIndex--;
                    }

                    if(isPallindrome && result.Length < (j-i))
                    {
                        result = str.Substring(i, j - i + 1);
                    }
                }
            }



            return result;
        }

        private static string FindPallindrome2(string str)
        {
            if (str == null)
                return null;

            if (str.Length < 3)
                return str;


            string result = String.Empty;

            int i = 0;
            int j = 1;
            while(i < str.Length)
            {

            }





            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal class FindFirstNotRepeatingCharacter
    {
        //aaabcccftttffdd -> b
        //abcbad -> c
        //abcabcabc -> -1

        internal static void Run()
        {

            Console.WriteLine("=================== FindFirstNotRepeatingCharacter ==================");



            string str = "aaabcccfttutffdd";

            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            for(int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                if(keyValuePairs.ContainsKey(c))
                {
                    keyValuePairs[c] = -1;
                }
                else if(!keyValuePairs.ContainsKey(c))
                {
                    keyValuePairs.Add(c, i);
                }
            }

            int charIndex = -1;
            foreach (var pair in keyValuePairs)
            {
                if (pair.Value == -1)
                    continue;


                if (pair.Value < charIndex || charIndex == -1)
                {
                    charIndex = pair.Value;
                }
            }
            Console.WriteLine("result=" + str[charIndex] );
        }
    }
}

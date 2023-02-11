using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal class PallindromeString
    {

        public static void Run()
        {
            Console.WriteLine($"============ PallindromeString ==================");

            string str = "abssba";
            var result = IsPallindrome(str);
            Console.WriteLine($"{str} = " + result);

            string str2 = "Я иду с мечем судия";
            var result2 = IsPallindrome(str2);
            Console.WriteLine($"{str2} = " + result2);



            string str3 = "Я иду с мечем судияeerer";
            var result3 = IsPallindrome(str3);
            Console.WriteLine($"{str3} = " + result3);
        }

        private static bool IsPallindrome(string str)
        {
            int i = 0;
            int j = str.Length-1;

            while(i < j)
            {
                if(!Char.IsLetter(str[i]))
                {
                    i++;
                    continue;
                }

                if (!Char.IsLetter(str[j]))
                {
                    j--;
                    continue;
                }

                if ( Char.ToUpperInvariant( str[i]) != Char.ToUpperInvariant( str[j] ))
                    return false;

                i++;
                j--;
            }

            return true;
        }

    }


}
